		private async Task SyncDataAsync(SyncMessage syncMessage)
		{
			if (syncMessage.State == SyncState.SyncContacts)
			{
				await this.SyncContactsAsync(); 
			}
		}
		
		private Task SyncContactsAsync()
		{
			foreach(var contact in this.AllContacts)
			{
			   // do synchronous data analysis
			}
		
			// ...
		
			// AddContacts is an async method
			return CloudInstance.AddContactsAsync(contactsToUpload);
		}
