            //Send To details
            string Phnumber = textBox1.Text;
            string message = textBox2.Text;
            //send From details
            string FromNumber = "917673943979";
            string password = "aaRvxtEbePyI/uBOqpqw9yeHlys=";
            string nickName = "Dayakar";
            WhatsApp wap = new WhatsApp(FromNumber, password, nickName, false, false);
            wap.OnConnectSuccess += () =>
                {
                    MessageBox.Show("Connected to whatsapp SuccessFully...");
                    wap.OnLoginSuccess += (PhoneNumber, data) =>
                    {
                        MessageBox.Show("Enterned");
                        wap.SendMessage(Phnumber, message);
                        MessageBox.Show("Message Sent Successfully...");
                    };
                    wap.OnLoginFailed += (data) =>
                    {
                        MessageBox.Show(data);
                        MessageBox.Show("Yes Failed login : {0}", data);
                    };
                    wap.Login();
                };
            wap.OnConnectFailed += (ex) =>
                {
                    MessageBox.Show("Conncetion Failure");
                };
            wap.Connect();
        }
