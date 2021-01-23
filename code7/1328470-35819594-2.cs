		public static class SystemInformation
		{
			public struct SYSTEM_INFO { ... };
			
			[DllImport(DllNames.Kernel32)]
			private static extern GetSystemInfoNative(out SYSTEM_INFO lpSystemInfo);
			
			public static SYSTEM_INFO GetSystemInfo()
			{
				SYSTEM_INFO info;
				GetSystemInfoNative(out info);
				return info;
			}
		}
		
