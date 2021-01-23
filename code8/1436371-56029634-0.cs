   		public static async Task<string> AuthenticateUser()
		{
			var t = Task.Run(() => ClassObject.AuthenticateUser("me"));
			t.Wait();
			Console.WriteLine(t.Result);
			Console.ReadLine();
			return "ok";
		}
