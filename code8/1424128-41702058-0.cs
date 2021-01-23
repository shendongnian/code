	void Main()
	{
		var userName = "main@user.com"; // The email address that has permissions to the shared mailbox
		var sharedMailboxAlias = "aliasName"; // This is the alias name as setup in Exchange
		var password = Util.GetPassword("Office365Password"); // Util.Password is a LinqPad method
		using (var client = new ImapClient())
		{
			client.Connect("outlook.office365.com", 993, true);
			client.AuthenticationMechanisms.Remove("XOAUTH2");
			client.Authenticate(userName + @"\" + sharedMailboxAlias, password);
			var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadOnly);
			Console.WriteLine("Total messages: {0}", inbox.Count);
			Console.WriteLine("Recent messages: {0}", inbox.Recent);
			client.Disconnect(true);
		}
	}
