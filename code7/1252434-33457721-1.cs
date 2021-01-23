            var fromAddress = new MailAddress("from@gmail.com");
            var toAddress = new MailAddress("to@hotmail.com");
            const string fromPassword = "generated password";
            const string subject = "Subject";
            const string body = "Body";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                try
                {
                    smtp.Send(message);
                    Console.WriteLine("Sent");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
