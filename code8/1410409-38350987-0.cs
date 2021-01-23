        public void SendEmail()
        {
            SmtpClient client = new SmtpClient("my host server", 25);
            var sender = "noreply@domain.com";
            var from = "actual sender";
            var to = "receiver";
            var replyTo = sender;
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(from);
                msg.Sender = new MailAddress(sender);
                msg.Subject = "Test auto reply from C#";
                msg.To.Add(new MailAddress(to));
                if (!string.IsNullOrWhiteSpace(replyTo))
                {
                    msg.ReplyToList.Add(replyTo);
                }
                msg.Body = "This is from C# email server to test auto reply.";
                client.Send(msg);
                msg.Dispose();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                client.Dispose();
            }
        }
 
