            using (var client = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(_sender, _password)
            })
            {
                using (var mail = new MailMessage(_sender, _recipient)
                {
                    Subject = _subject,
                    Body = _message
                })
                {
                    client.Send(mail);
                }
            }
