    using Newtonsoft.Json;
    public string Demo()
    {
		var mails = new List<Mail>();
		var mail = new Mail();
		mail.To = new List<Recepient>{
			new Recepient
			{
				EntryType = 2, 
				username = "jack", 
				email = "test@gmail.com"
			}
        };
		mail.Cc = new List<Recepient>();
	    mail.Bcc = new List<Recepient>();
		mails.Add(mail);
		return JsonConvert.SerializeObject(mails);
    }
