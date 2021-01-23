    WhatsUserManager manager = new WhatsUserManager();
                user = manager.CreateUser(txtphonenumber.Text, "NAME");
                var thread = new Thread(ThreadState =>
                {
                    UpdateTextBox textbox = UpdateDataTextBox;
                    WhatSocket.Create(txtphonenumber.Text, textBoxPass.Text, textBoxNick.Text, true);
                    WhatSocket.Instance.OnConnectSuccess += () =>
                    {
                        if (txtstatus.InvokeRequired)
                        {
                            Invoke(textbox, txtstatus, "connected...");
                        }
    
                        WhatSocket.Instance.OnLoginSuccess += (phone, data) =>
                        {
                            //WhatSocket.Instance.PollMessages(true);
                            WhatSocket.Instance.SendMessage("SENDER_NUMBER", "TEST");
                            Invoke(textbox, txtstatus, "Login Success...");
                        };
                        WhatSocket.Instance.OnLoginFailed += (data) =>
                        {
                            if (txtstatus.InvokeRequired)
                            {
                                Invoke(textbox, txtstatus, string.Format("\r\n Login Failed : {0}", data));
                            }
                        };
                        WhatSocket.Instance.OnGetMessage += (node,from,id,name,message,receipt_sent) => 
                        {
                            Invoke(textbox, txtstatus, string.Format("\r\n Name : {0}, Message : {1}", name,message));
                        };
                        WhatSocket.Instance.Login();
                    };
                    WhatSocket.Instance.OnConnectFailed += (ex) =>
                    {
                        if (txtstatus.InvokeRequired)
                        {
                            Invoke(textbox, txtstatus, string.Format("\r\n Connect Failed : {0}", ex.StackTrace));
                        }
                    };
                    WhatSocket.Instance.Connect();
                }) { IsBackground = true };
                thread.Start();
