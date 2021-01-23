		public string SendEmail()
        {
			var tasks = new List<Task>();
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("myemail@gmail.com", "*****");
            client.EnableSsl = true;
            foreach (var emailAddress in EmailList)
            {
                var message = new MailMessage("myemail@gmail.com", emailAddress);
                message.Subject = "hi";
                tasks.Add(client.SendAsync(message));
            }
			while(tasks.Count > 0)
			{
				var idx = Task.WaitAny(tasks.ToArray());
				tasks.RemoveAt(idx);
			}
            return "done";
        }
