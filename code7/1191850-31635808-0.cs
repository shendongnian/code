                    try
                    {
                        var csp = new RSACryptoServiceProvider();
                        var reader = new StreamReader(address);
                        var xml = reader.ReadToEnd();
                        csp.FromXmlString(xml);
                    }
                    catch
                    {
                        //not a rsa public key                   
                    }
