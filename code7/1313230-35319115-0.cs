        public void SendMail()
        {
            try
            {
                var fromAddress = new MailAddress("from@example.com", "Some text");
                var toAddress = new MailAddress("to@example.com");
                const string fromPassword = "from account password";
                var smtp = new SmtpClient
                {
                    Host = "smtp.example.com",
                    Port = "your host port", //for gmail is 587
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "Test",
                    Body = "Message " + DateTime.Now.ToString()
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                //do something
            }
       }
