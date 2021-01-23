        public Task SendAsync(IdentityMessage message, IEnumerable<KeyValuePair<string, Stream>> attach)
        {
            var myMessage = new SendGridMessage() { From = new MailAddress("my@email.com") };
            myMessage.AddTo(message.Destination);
            myMessage.Subject = message.Subject;
            myMessage.Html = message.Body;
            myMessage.Text = message.Body;
            var credentials = new NetworkCredential("myuser", "mypassword");
            var transportWeb = new Web(credentials);
            foreach (var file in attach)
            {
                myMessage.AddAttachment(file.Value,file.Key);
            }
            
            return transportWeb.DeliverAsync(myMessage);
        }
