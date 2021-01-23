                var clientSection = config.GetSectionGroup("system.serviceModel").Sections[2].ElementInformation;
                PropertyInformationCollection endpoints = clientSection.Properties;
                foreach (PropertyInformation endpoint in endpoints)
                {
                    foreach (ServiceElement key in (ServiceElementCollection)endpoint.Value)
                    {
                        var j = key.Endpoints[0];
                        ServiceHost host = new ServiceHost(j.Contract.GetType(), new Uri(key.Host.BaseAddresses[0].BaseAddress));
                        host.AddServiceEndpoint(j.Contract.GetType(), new BasicHttpBinding(), j.Address);
                    }
                }
