		public async Task ImportContactByPhoneNumberAndSendMessage()
		{
			// User should be already authenticated!
			var store = new FileSessionStore();
			var client = new TelegramClient(store, "session");
			await client.Connect();
			Assert.IsTrue(client.IsUserAuthorized());
			var res = await client.ImportContactByPhoneNumber(NumberToSendMessage);
			Assert.IsNotNull(res);
			await client.SendMessage(res.Value, "Test message from TelegramClient");
		}
