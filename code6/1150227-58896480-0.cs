            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(mailOut, pswMailOut);
            client.Port = 587; // 25 587
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            MailMessage mail = new MailMessage();            
            mail.From = new MailAddress(mailOut, displayNameMailOut);
            mail.To.Add(new MailAddress(mailOfTestDestine));
            mail.Subject = "A special subject";
            mail.Body = sb.ToString();
            client.Send(mail);
