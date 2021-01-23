           public void MyWebServiceClient()
		   {
			    using (var client = new MyWebService())
				{
					try
					{
						//calls the web service
						client.Url = //Your server EndpointUri;
					  
						//assign cert
						ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
						string certificatePath = //certificate path
						string certificatePassword = //certificate password
						X509Certificate2 cert = new X509Certificate2(certificatePath, certificatePassword, X509KeyStorageFlags.MachineKeySet);
						client.ClientCertificates.Add(cert);
                        //var result = client.WebServiceCall(your input);
					}
					catch (Exception ex)
					{
						throw new Exception("Error " + ex.Message);
					}
				}
			}
			
			
	    public bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {            
            // accept all certificates
            return true;
        }
			
			
