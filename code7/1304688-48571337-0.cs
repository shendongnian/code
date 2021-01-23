    public static bool Send()
        {
            try
            {
                var fromAddress = new MailAddress("xyz@example.com");
                var toAddress = new MailAddress("xyziahd@example.com");
                const string subject = "subjects";
                const string userName = "serverCredentail";
                const string Password = "serverpassword";
                const string body = "Body";
                var smtp = new SmtpClient
                {
                    Host = "servernameexample.com",
                    Port = 25,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(userName, Password)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
