        static void Main()
        {
            SendEmail().Wait();
        }
        static async Task SendEmail()
        {
            var myMessage = new SendGridMessage();
            myMessage.From = new MailAddress("from_emal");
            myMessage.AddTo("to_email");
            myMessage.Subject = "Testing the SendGrid Library";
            myMessage.Html = "<p>Hello World!</p>";
            myMessage.Text = "Hello World plain text!";
            var credentials = new NetworkCredential("sendgrid_user", "sendgrid_pass");
            var transportWeb = new Web(credentials);
            await transportWeb.DeliverAsync(myMessage);            
        }
