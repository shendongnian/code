		public Task SendEmailsAsync(IList<Email> emails)
		{
			var emailTasks = emails.Select(SendDataAsync);
			return Task.WhenAll(allTasks);
		}
		
