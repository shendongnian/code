        static void Main()
        {
            var config = new JobHostConfiguration();
            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }
            config.UseSendGrid();
	    //The function below has to wait in order for the email to be sent
            SendEmail(*Your SendGrid API key*).Wait();
            
            
        }
        public static async Task SendEmail(string key)
        {
            
            dynamic sg = new SendGridAPIClient(key);
            Email from = new Email("from@domain.com");
            string subject = "Test";
            Email to = new Email("to@domain.com");
            Content content = new Content("text/html", "CONTENT HERE");
            Mail mail = new Mail(from, subject, to, content);
         
            dynamic s = await sg.client.mail.send.post(requestBody: mail.Get());
             
        }
    
