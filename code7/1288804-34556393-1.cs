    public void SendToMail()
        {
            try
            {
                const string vMailFm = "admin@example.com";
                var vMailTo = ((Session["EmailId"].ToString() == "") ? "admin@example.com" : Session["EmailId"].ToString());
                MailMessage vMail = new MailMessage(vMailFm, vMailTo);
            
                var vDetails = "";
                vDetails += "Result Information";
                 
    
                vMail.Subject = subject;
                vMail.Body = vDetails;
                vMail.IsBodyHtml = true;
                SmtpClient vSmpt = new SmtpClient();
                System.Net.NetworkCredential smtpUser = new System.Net.NetworkCredential("admin@example.com", "1234567");
                vSmpt.Host = "example.com";
               // vSmpt.Port = 587;//for local
                vSmpt.Port = 25;//for online
                vSmpt.EnableSsl = false;
                vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                vSmpt.UseDefaultCredentials = false;
                vSmpt.Credentials = smtpUser;
                vSmpt.Send(vMail);
            }
            catch (Exception)
            {
                // ignored
            }
        }
