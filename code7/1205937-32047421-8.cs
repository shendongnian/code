		public async Task LoadDataAsync()
		{
			while (Main.IsProcessRunning)
			{
				var emails = new dummyRepositories().GetAllEmails(); 
				await SendEmailsAsync(emails);
			}
		}
