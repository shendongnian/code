    using Opc.Ua;
    using Opc.Ua.Client;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Security;
    namespace MyHomework
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Step 1 - Create a config.");
                var config = new ApplicationConfiguration()
                {
                    ApplicationName = "MyHomework",
                    ApplicationType = ApplicationType.Client,
                    SecurityConfiguration = new SecurityConfiguration { ApplicationCertificate = new CertificateIdentifier { StoreType = @"Windows", StorePath = @"CurrentUser\My", SubjectName = Utils.Format(@"CN={0}, DC={1}", "MyHomework", System.Net.Dns.GetHostName()) }, TrustedPeerCertificates = new CertificateTrustList { StoreType = @"Windows", StorePath = @"CurrentUser\TrustedPeople", }, NonceLength = 32, AutoAcceptUntrustedCertificates = true },
                    TransportConfigurations = new TransportConfigurationCollection(),
                    TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
                    ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 }
                };
                config.Validate(ApplicationType.Client);
                if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
                {
                    config.CertificateValidator.CertificateValidation += (s, e) => { e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted); };
                }
    
                Console.WriteLine("Step 2 - Create a session with your server.");
                using (var session = Session.Create(config, new ConfiguredEndpoint(null, new EndpointDescription("opc.tcp://" + Dns.GetHostName() + ":62541")), true, "", 60000, null, null))
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
