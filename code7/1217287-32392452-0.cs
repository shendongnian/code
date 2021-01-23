    var client = new SmtpClient
            {
                Host = txtOutGoingServer.Text,
                Port = Convert.ToInt16(txtServerPort.Text),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(txtUserName.Text, txtPassword.Password),
                Timeout = 20000
            };
     try
           {
               m.To.Add(new MailAddress(dr[0].ToString().Trim()));
               m.From = new MailAddress(txtUserName.Text);
               foreach (var attachment in Attactments)
           {
             m.Attachments.Add(new Attachment(attachment));
           }
             client.Send(m);
             m.To.Clear();
             m.Attachments.Clear();
             Success.Add(dr[0].ToString());
           }
             catch (SmtpException esException)
           {
             Errors.Add("Error sending to " + dr[0].ToString() + " " + esException.Message);
           }
             catch (Exception ex)
           {
             Errors.Add("Error sending to " + dr[0].ToString() + " " + ex.Message);
           }
