    using Opc.Ua;   // Install-Package OPCFoundation.NetStandard.Opc.Ua
    using Opc.Ua.Client;
    using Opc.Ua.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    namespace MyHomework
    {
      class Program
      {
        static void Main(string[] args)
        {
            Console.WriteLine("Step 1 - Create application configuration and certificate.");
            var config = new ApplicationConfiguration()
            {
                ApplicationName = "MyHomework",
                ApplicationUri = Utils.Format(@"urn:{0}:MyHomework", System.Net.Dns.GetHostName()),
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration {
                    ApplicationCertificate = new CertificateIdentifier { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\MachineDefault", SubjectName = Utils.Format(@"CN={0}, DC={1}", "MyHomework", System.Net.Dns.GetHostName()) },
                    TrustedIssuerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Certificate Authorities" },
                    TrustedPeerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Applications" },
                    RejectedCertificateStore = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\RejectedCertificates" },
                    AutoAcceptUntrustedCertificates = true,
                    AddAppCertToTrustedStore = true
                },
                TransportConfigurations = new TransportConfigurationCollection(),
                TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
                ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 },
                TraceConfiguration = new TraceConfiguration()
            };
            config.Validate(ApplicationType.Client).GetAwaiter().GetResult();
            if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                config.CertificateValidator.CertificateValidation += (s, e) => { e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted); };
            }
            var application = new ApplicationInstance
            {
                ApplicationName = "MyHomework",
                ApplicationType = ApplicationType.Client,
                ApplicationConfiguration = config
            };
            application.CheckApplicationInstanceCertificate(false, 2048).GetAwaiter().GetResult();
            var selectedEndpoint = CoreClientUtils.SelectEndpoint("opc.tcp://" + Dns.GetHostName() + ":48010", useSecurity: true, operationTimeout: 15000);
            Console.WriteLine($"Step 2 - Create a session with your server: {selectedEndpoint.EndpointUrl} ");
            using (var session = Session.Create(config, new ConfiguredEndpoint(null, selectedEndpoint, EndpointConfiguration.Create(config)), false, "", 60000, null, null).GetAwaiter().GetResult())
            {
                Console.WriteLine("Step 3 - Browse the server namespace.");
                ReferenceDescriptionCollection refs;
                Byte[] cp;
                session.Browse(null, null, ObjectIds.ObjectsFolder, 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out cp, out refs);
                Console.WriteLine("DisplayName: BrowseName, NodeClass");
                foreach (var rd in refs)
                {
                    Console.WriteLine("{0}: {1}, {2}", rd.DisplayName, rd.BrowseName, rd.NodeClass);
                    ReferenceDescriptionCollection nextRefs;
                    byte[] nextCp;
                    session.Browse(null, null, ExpandedNodeId.ToNodeId(rd.NodeId, session.NamespaceUris), 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out nextCp, out nextRefs);
                    foreach (var nextRd in nextRefs)
                    {
                        Console.WriteLine("+ {0}: {1}, {2}", nextRd.DisplayName, nextRd.BrowseName, nextRd.NodeClass);
                    }
                }
                Console.WriteLine("Step 4 - Create a subscription. Set a faster publishing interval if you wish.");
                var subscription = new Subscription(session.DefaultSubscription) { PublishingInterval = 1000 };
                Console.WriteLine("Step 5 - Add a list of items you wish to monitor to the subscription.");
                var list = new List<MonitoredItem> { new MonitoredItem(subscription.DefaultItem) { DisplayName = "ServerStatusCurrentTime", StartNodeId = "i=2258" } };
                list.ForEach(i => i.Notification += OnNotification);
                subscription.AddItems(list);
                Console.WriteLine("Step 6 - Add the subscription to the session.");
                session.AddSubscription(subscription);
                subscription.Create();
                Console.WriteLine("Press any key to remove subscription...");
                Console.ReadKey(true);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
        private static void OnNotification(MonitoredItem item, MonitoredItemNotificationEventArgs e)
        {
            foreach (var value in item.DequeueValues())
            {
                Console.WriteLine("{0}: {1}, {2}, {3}", item.DisplayName, value.Value, value.SourceTimestamp, value.StatusCode);
            }
        }
      }
    }
