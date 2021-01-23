     static void Main()
        {               
            XmlTextReader myReader = new XmlTextReader("https://domainws.ficora.fi/fiDomain/DomainNameWS_FicoraDomainNameWS.svc?wsdl");
            if (ServiceDescription.CanRead(myReader))
            {
                ServiceDescription myDescription = ServiceDescription.Read(myReader);
                Dictionary<string, Service> Services;
                foreach (Service srv in myDescription.Services)
                {
                    Services = new Dictionary<string, Service>();
                    Services.Add(srv.Name, srv);
                    foreach (Port p in srv.Ports)
                    {
                        Binding b = myDescription.Bindings[p.Binding.Name];
                        foreach (Object e in b.Extensions)
                        {
                            if (e is Soap12Binding || e is SoapBinding)
                            {
                                //only change right here:
                                Port ptobject = srv.Ports[b.Type.Name];
                                
                            }
                        }
                    }
                }
            }
        }
