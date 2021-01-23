    using System;
    using System.Diagnostics;
    using System.Fabric;
    using System.Fabric.Description;
    using System.Globalization;
    using System.Net;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Services.Communication.Runtime;
    namespace UdpService
    {
        public class UdpCommunicationListener : ICommunicationListener, IDisposable
        {
            private readonly CancellationTokenSource processRequestsCancellation = new CancellationTokenSource();
            public int Port { get; set; }
            private UdpClient server;
            /// <summary>
            /// Stops the Server Ungracefully
            /// </summary>
            public void Abort()
            {
                this.StopWebServer();
            }
            /// <summary>
            /// Stops the Server Gracefully
            /// </summary>
            /// <param name="cancellationToken">Cancellation Token</param>
            /// <returns>Task for Asynchron usage</returns>
            public Task CloseAsync(CancellationToken cancellationToken)
            {
                this.StopWebServer();
                return Task.FromResult(true);
            }
            /// <summary>
            /// Free Resources
            /// </summary>
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
            /// <summary>
            /// Initializes Configuration
            /// </summary>
            /// <param name="context">Code Package Activation Context</param>
            public void Initialize(ICodePackageActivationContext context)
            {
                EndpointResourceDescription serviceEndpoint = context.GetEndpoint("ServiceEndpoint");
                this.Port = serviceEndpoint.Port;
            }
            /// <summary>
            /// Starts the Server
            /// </summary>
            /// <param name="cancellationToken">Cancellation Token</param>
            /// <returns>Task for Asynchron usage</returns>
            public Task<string> OpenAsync(CancellationToken cancellationToken)
            {
                try
                {
                    this.server = new UdpClient(this.Port);
                }
                catch (Exception ex)
                {
                }
                ThreadPool.QueueUserWorkItem((state) =>
                {
                    this.MessageHandling(this.processRequestsCancellation.Token);
                });
                return Task.FromResult("udp://" + FabricRuntime.GetNodeContext().IPAddressOrFQDN + ":" + this.Port);
            }
            protected void MessageHandling(CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, this.Port);
                    byte[] receivedBytes = this.server.Receive(ref ipEndPoint);
                    this.server.Send(receivedBytes, receivedBytes.Length, ipEndPoint);
                    Debug.WriteLine("Received bytes: " + receivedBytes.Length.ToString());
                }
            }
            /// <summary>
            /// Receives the specified endpoint.
            /// </summary>
            /// <param name="endpoint">The endpoint.</param>
            /// <returns></returns>
            public Task<byte[]> Receive(ref IPEndPoint endpoint)
            {
                return Task.FromResult(this.server.Receive(ref endpoint));
            }
            /// <summary>
            /// Free Resources and Stop Server
            /// </summary>
            /// <param name="disposing">Disposing .NET Resources?</param>
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (this.server != null)
                    {
                        try
                        {
                            this.server.Close();
                            this.server = null;
                        }
                        catch (Exception ex)
                        {
                            ServiceEventSource.Current.Message(ex.Message);
                        }
                    }
                }
            }
            /// <summary>
            /// Stops Server and Free Handles
            /// </summary>
            private void StopWebServer()
            {
                this.processRequestsCancellation.Cancel();
                this.Dispose();
            }
        }
    }
