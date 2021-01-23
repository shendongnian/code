    MailMessage mailMessage = new MailMessage("From_User_Email", "To_Whom_Email");
            mailMessage.Subject = "This is a test email";
            mailMessage.Body = "This is a test email. Please reply if you receive it.";
            SmtpClient smtpClient = new SmtpClient();
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "From_User_Email",
                Password = "User_Password"
            };
            //smtpClient.UseDefaultCredentials = false;
            smtpClient.Send(mailMessage);
