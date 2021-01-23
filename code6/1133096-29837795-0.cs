    class MailModule
    {
        public static void CreateMessage(string Server, int Port, string From, IList<string> to, string Subject, string Body)
        {
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("username", "password");
            var message = new MailMessage();
            message.From = new MailAddress(From);
            message.Subject = subject;
            message.Body = body;
            to.ForEach(x => message.To.Add(x));
            SmtpClient client = new SmtpClient(Server);
            client.Port = Port;
            client.Credentials = basicAuthenticationInfo;
            try
            {
                client.Send(message);
                MessageBox.Show("Shout Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                message.Dispose();
            }
            catch (Exception ex)
            {
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                MessageBox.Show(message.DeliveryNotificationOptions.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
