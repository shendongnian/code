		public static class ErrorHandling
		{
			// It is private so no FxCop should trouble you
			[DllImport(DllNames.Kernel32)]
			private static extern void SetLastErrorNative(UInt32 dwErrCode);
			
			public static void SetLastError(Int32 errorCode)
			{
				SetLastErrorNative(unchecked((UInt32)errorCode));
			}
		}
