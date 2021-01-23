      try 
      {	
               MailMessage msg = new MailMessage ();
               MailAddress fromAdd = new MailAddress("fromemail@email.com");
               msg.[To].Add("toemail@email.com");
               msg.Subject = "Choose Session Members";
               msg.From = fromAdd;
               msg .IsBodyHtml = true;
               msg.Priority = MailPriority.Normal;
               msg .BodyEncoding = Encoding.Default;
               msg.Body = "<center><table><tr><td><h1>Your Message</h1><br/><br/></td></tr>";
               msg.Body = msg.Body + "</table></center>";
               SmtpClient smtpClient = new SmtpClient ("smtp.yourserver.com", "25");
               smtpClient.EnableSsl = true;
               smtpClient.UseDefaultCredentials = false;
               smtpClient.Credentials = new System.Net.NetworkCredential("yourname@yourserver.com", "password");
               smtpClient .DeliveryMethod = SmtpDeliveryMethod.Network;
               smtpClient.Send(msg);
               smtpClient.Dispose();
            }
        catch (exception ex){
            Label1.Text  = ex.ToString();
        }
