	private Task SyncContacts()
	{
		foreach(var contact in this.AllContacts)
		{
		   // ** CPU intensive work here.
		}
		// Will return immediately with a Task which will complete asynchronously
		return CloudInstance.AddContactsAsync(contactsToUpload);
	}
