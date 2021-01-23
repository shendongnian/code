	public static async Task LogonUser(string userName, string password)
	{
		Console.WriteLine("Logging on user {0} with password {1}", userName, password);
		//Do the actual logon work here
		await Task.Delay(500);  
		Console.WriteLine("Done logging on user {0}", userName);
	}
