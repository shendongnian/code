            string certificateFile = @"C:\XYZ\MyTest.cer";
                   
            System.Security.Cryptography.X509Certificates.X509Certificate x509Certificate = new System.Security.Cryptography.X509Certificates.X509Certificate(certificateFile);
            //X509Certificate x509Certificate = X509Certificate.CreateFromCertFile(certificateFile);
            MyTest.DataService rdf = new MyTest.DataService();
            RvsDataFeed[] rvs = rdf.GetRvsDataFeed();
            txtXml.Text = "";
            if (rvs != null)
            {
                foreach (RvsDataFeed rvsdata in rvs)
                {
                    try
                    {
                      
                        TrackingRequest wbttreq = new TrackingRequest();
                        ClientType cit = new ClientType();
                      
                        cit.requestorAppName = "MMM";
                        cit.requestorUserName = rvsdata.ID;
                        wbttreq.ClientInfo = cit;
                     
                        ClientWSDL.DataUtility xyzWSDL = new ClinetWSDL.DataUtility();
                        xyzWSDL.Url = "http://xyz.xy";
                        xyzWSDL.ClientCertificates.Add(x509Certificate);
                     
                        txtXml.Text = txtXml.Text + Environment.NewLine + SerializeToString(td);
                        TrackingResponse res = new TrackingResponse();
                        xyzWSDL.WriteBack(wbttreq);
                        
                        rdf.LogRvsDataFeedSent(rvsdata.DataFeedID);
                    }
                    catch (Exception ex)
                    {
                        txtXml.Text = txtXml.Text + Environment.NewLine + ex.Message;
                    }
                }
            }
        }
