    public class EmailService : IIdentityMessageService
    {
        const string from = "mail@domain.com";
        const string username = "username";//Environment.GetEnvironmentVariable("SENDGRID_USER");
        const string pswd = "password";//Environment.GetEnvironmentVariable("SENDGRID_PASS");
        private List<KeyValuePair<string, Stream>> _attachments;
        private List<KeyValuePair<string, string>> _recipients;
        public Task SendAsync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage() { From = new MailAddress(from) };
            var credentials = new NetworkCredential(username, pswd);
            var transportWeb = new Web(credentials);
            myMessage.AddTo(message.Destination);
            if (_recipients != null)
            {
                _recipients.ForEach(r => myMessage.AddTo(string.Format("{0} {1}", r.Key, r.Value)));
            }
            myMessage.Subject = message.Subject;
            myMessage.Html = message.Body;
            myMessage.Text = message.Body;
            if (_attachments != null)
            {
                foreach (var attachment in _attachments)
                {
                    myMessage.AddAttachment(attachment.Value, attachment.Key);
                }
            }
            return transportWeb.DeliverAsync(myMessage);
        }
        public Task SendAsync(IdentityMessage message, IEnumerable<KeyValuePair<string, Stream>> attachments)
        {
            var myMessage = new SendGridMessage() { From = new MailAddress(from) };
            var credentials = new NetworkCredential(username, pswd);
            var transportWeb = new Web(credentials);
            myMessage.AddTo(message.Destination);
            myMessage.Subject = message.Subject;
            myMessage.Html = message.Body;
            myMessage.Text = message.Body;
            foreach (var attachment in attachments)
            {
                myMessage.AddAttachment(attachment.Value, attachment.Key);
            }
            return transportWeb.DeliverAsync(myMessage);
        }
        public Task SendAsync(IdentityMessage message, KeyValuePair<string, Stream> attachment)
        {
            var myMessage = new SendGridMessage() { From = new MailAddress(from) };
            var credentials = new NetworkCredential(username, pswd);
            var transportWeb = new Web(credentials);
            myMessage.AddTo(message.Destination);
            myMessage.Subject = message.Subject;
            myMessage.Html = message.Body;
            myMessage.Text = message.Body;
            myMessage.AddAttachment(attachment.Value, attachment.Key);
            return transportWeb.DeliverAsync(myMessage);
        }
        public void AddTo(string name,string mail)
        {
            _recipients = _recipients ?? new List<KeyValuePair<string, string>>();
            _recipients.Add(new KeyValuePair<string, string>(name, string.Format("<{0}>", mail)));
        }
        public void AddAttachment(string name, Stream file)
        {
            _attachments = _attachments ?? new List<KeyValuePair<string, Stream>>();
            _attachments.Add(new KeyValuePair<string, Stream>(name, file));
        }
        public void AddAttachment<T>(string name, T records)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(records);
            var bytes = Encoding.UTF8.GetBytes(json);
            var ms = new MemoryStream(bytes);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            _attachments = _attachments ?? new List<KeyValuePair<string, Stream>>();
            _attachments.Add(new KeyValuePair<string, Stream>(name, ms));
        }
    }
