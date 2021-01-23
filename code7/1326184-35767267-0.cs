            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress("YourEmail@hotmail.com", "XXXX"));
            msg.From = new MailAddress("XXX@msdnofficedev.onmicrosoft.com", "XXX");
            msg.Subject = "This is a Test Mail";
            msg.Body = "This is a test message using Exchange OnLine";
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("XXX@msdnofficedev.onmicrosoft.com", "YourPassword");
            client.Port = 587; // You can use Port 25 if 587 is blocked
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
            
            }
            catch (Exception ex)
            {
               
            }
