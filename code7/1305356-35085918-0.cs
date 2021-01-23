    WhatsApp wa = new WhatsApp("503555555555555", "get the password using WART", "your nickname", false, false);
                wa.OnConnectSuccess += () =>
                {
                    Response.Write("connect");
                    wa.OnLoginSuccess += (phno,data) =>
                    {
                        wa.SendMessage("Destinatino number (50377777777777)", "Youre custom message");
                    };
    
                    wa.OnLoginFailed += (data) =>
                    {
                        Response.Write("login failed"+data);
                    };
                    wa.Login();
                };
                wa.OnConnectFailed += (ex) =>
                                          {
                                              Response.Write("connection failed");
                                          }
                    ;
    
                wa.Connect();
