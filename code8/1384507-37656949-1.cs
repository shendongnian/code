    //The path to the certificate.
    string certPath = "C:/AUTH_RSA256_e9f5afab50193175883774ec07bac05cb8c9e2d7.p12";
                
    //Password to signing a certificate
    string certPassword = "123456";
  
    //IIN or BIN persom who signing ESF on esf_gov site
    var tin = "123456789021";
    
    //Load the certificate into an X509Certificate object.
    X509Certificate x509Cert = new X509Certificate(certPath, certPassword);
    
    //Transfer sertificate to string value of base64
    var certPEM = ExportToPEM(x509Cert);
    
    
    using (SessionServiceClient client = new SessionServiceClient())
                {
                    using (new OperationContextScope(client.InnerChannel))
                    {
                        OperationContext.Current.OutgoingMessageHeaders.Add(
                            new MySoapSecurityHeader("123456789011", "TestPass123"));
                                
                        //Create session for a work with site ESF
                        CreateSessionRequest createSessionRequest = new CreateSessionRequest
                        {
                            tin = tin,
                            x509Certificate = certPEM
                        };
    
                        var response = client.createSession(createSessionRequest);
                        MessageBox.Show("Session ID is: " + response.sessionId, "Information message",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
    
                        //Close session for a work with site ESF
                        CloseSessionRequest closeSessionRequest = new CloseSessionRequest
                        {
                            sessionId = response.sessionId,
                            tin = tin,
                            x509Certificate = certPEM
                        };
    
                        var closeResponse = client.closeSession(closeSessionRequest);
                    }
                }
    
            }
            public static string ExportToPEM(X509Certificate cert)
            {
                //Export certificate, get baty array, convert in base64 string
                return Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks);
            }
