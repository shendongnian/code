	public class MailNotification{
		public string From {get;set;}
		public string To {get;set;}
		public string Subject {get;set;}
		public string Body {get;set;}
	}
	
    public class Functions
    {
		public static void MorningMail([TimerTrigger("0 0 9 1/1 * ? *", RunOnStartup = true)]
		TimerInfo info, [Queue]("mail") ICollector<MailNotification> mails)
		{
			var remCheckOuts = // query code here                                
		 into grouped
		 select new Reminder
		 {
			  /// populate viewmodel 
		 });    
		// send emails
		foreach (var i in remCheckOuts)
		{
				mails.Add(new MailNotification(){
					To = "test2@test2.com",
					From = "test@test.com",
					Subject = "Whatever Subject you want",
					Body = "construct the body here"
				});	
					
		  } 
		}
		public static void EveningMail([TimerTrigger("0 0 18 1/1 * ? *", RunOnStartup = true)]
		TimerInfo info, [Queue]("mail") ICollector<MailNotification> mails)
		{
			var remCheckOuts = // query code here                                
		 into grouped
		 select new Reminder
		 {
			  /// populate viewmodel 
		 });    
		// send emails
		foreach (var i in remCheckOuts)
		{
				mails.Add(new MailNotification(){
					To = "test2@test2.com",
					From = "test@test.com",
					Subject = "Whatever Subject you want",
					Body = "construct the body here"
				});	
					
		  } 
		}
	
        public static void SendMails([QueueTrigger(@"mails")] MailNotification order,
            [SendGrid(
                To = "{To}",
				From = "{From}",
                Subject = "{Subject}",
                Text = "{Body}")]
            SendGridMessage message)
        {
            ;
        }
    }
