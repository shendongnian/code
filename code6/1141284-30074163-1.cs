		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool InitiateShutdown(string lpMachineName,
			string lpMessage,
			UInt32 dwGracePeriod,
			UInt32 dwShutdownFlags,
			UInt32 dwReason);
		public static void ShutdownWorkstation()
		{
			UInt32 flags = 0x8;
			UInt32 reason = 0;
			UInt32 gracePeriod = 5;
			InitiateShutdown(System.Environment.MachineName, "", gracePeriod, flags, reason);
			//Console.WriteLine("Dummy Shutdown");
		}
		public static void RestartWorkstation()
		{
			UInt32 flags = 0x4;
			UInt32 reason = 0;
			UInt32 gracePeriod = 5;
			InitiateShutdown(System.Environment.MachineName, "", gracePeriod, flags, reason);
			//Console.WriteLine("Dummy Restart");
		}
