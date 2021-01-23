     NetworkCredential netCred = new NetworkCredential(
                    textBox_Username.Text,
                    textBox_password.Password);
                    BasicAuthCredential basicCred = new BasicAuthCredential(netCred);
                    TfsClientCredentials tfsCred = new TfsClientCredentials(basicCred);
                    tfsCred.AllowInteractive = false;
    
                    TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(
                        new Uri("https://fabrikam.visualstudio.com/DefaultCollection"),
                        tfsCred);
    
                    tpc.Authenticate();
