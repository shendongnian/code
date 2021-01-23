    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Fabric;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Services.Communication.Runtime;
    using Microsoft.ServiceFabric.Services.Runtime;
    namespace UdpService
    {
        /// <summary>
        /// An instance of this class is created for each service instance by the Service Fabric runtime.
        /// </summary>
        internal sealed class UdpService : StatelessService
        {
            private UdpCommunicationListener listener;
            public UdpService(StatelessServiceContext context)
                : base(context)
            { }
            protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
            {
                yield return new ServiceInstanceListener(initParams =>
                {
                    this.listener = new UdpCommunicationListener();
                    this.listener.Initialize(initParams.CodePackageActivationContext);
                    return this.listener;
                });
            }
        }
    }
