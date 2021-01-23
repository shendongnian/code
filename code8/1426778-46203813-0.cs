    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Security.Cryptography.X509Certificates;
    
    namespace Example.Lib.Net
    {
        internal class TcpWebServer : IDisposable
        {
            private TcpListener m_Listener = null;
            private bool m_IsSSL = false;
            private X509Certificate2 m_ServerCertificate = null;
    
            internal X509Certificate2 ServerCertificate
            {
                get { return m_ServerCertificate; }
                set { m_ServerCertificate = value; }
            }
    
            internal void Start(string ip, int port, bool useSsl = false)
            {
                if (useSsl) // for player streams always use ssl to
                {
                    m_IsSSL = true;
                    m_ServerCertificate = new X509Certificate2("./cert/cert.pfx", "pass");
    
                    X509Store store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(m_ServerCertificate);
                    store.Close();
                }
    
                IPAddress ipAddr = IPAddress.Any;
                if (ip != "*") IPAddress.TryParse(ip, out ipAddr);
    
                try
                {
                    m_Listener = new TcpListener(ipAddr, port);
                    m_Listener.Start();
                    m_Listener.BeginAcceptTcpClient(OnClientAccepted, m_Listener);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
    
            private void OnClientAccepted(IAsyncResult ar)
            {
                TcpListener listener = ar.AsyncState as TcpListener;
    
                if (listener == null)
                    return;
    
                TcpClient client = listener.EndAcceptTcpClient(ar);
                client.ReceiveBufferSize = 65535;
                client.Client.ReceiveBufferSize = 65535;
    
                TcpWebConnection con = new TcpWebConnection(client, this, m_IsSSL);
    
                listener.BeginAcceptTcpClient(OnClientAccepted, listener);
            }
        }
    }
