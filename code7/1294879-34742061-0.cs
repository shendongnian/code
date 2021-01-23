		public static void Main(string[] args)
		{
			const ulong dataFromAD = 0xFFFFE86D079B8000;
			var ticks = -unchecked((long)dataFromAD);
			var maxPwdAge = TimeSpan.FromTicks(ticks);
			
			var pwdLastSet = new DateTime(2015,12,16,9,19,13);
			
			var pwdDeadline = (pwdLastSet + maxPwdAge).Date;
			
			Console.WriteLine(pwdDeadline);
			
			Console.WriteLine(pwdDeadline - DateTime.Today);
			
			Console.ReadKey(true);
		}
