    protected void sendmail(string reciever, string subject, string body)
        {
            string senderID = "sender email id";
            string pwd = "password ";
            string result = "Message Sent Successfully";
            try
            {
                SmtpClient smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, pwd),
                    Timeout = 30000
                };
                MailMessage msg = new MailMessage(senderID, reciever, subject, body);
                msg.IsBodyHtml = true;
                smtpClient.Send(msg);
            }
            catch
            {
                result = "Error Sending Mail";
            }
           Response.Write(result );
        }
