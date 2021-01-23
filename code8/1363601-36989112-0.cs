            if (!Fiddler.CertMaker.rootCertExists())
                    {
                        if (!Fiddler.CertMaker.createRootCert())
                        {
                            throw new Exception("Unable to create cert for FiddlerCore.");
                }
            }
            if (!Fiddler.CertMaker.rootCertIsTrusted())
            {
                if (!Fiddler.CertMaker.trustRootCert())
                {
                    throw new Exception("Unable to install FiddlerCore's cert.");
                }
            }
