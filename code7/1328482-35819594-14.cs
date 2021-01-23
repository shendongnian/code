		public static class Window
		{
			public class WindowHandle : SafeHandle ...
			
			[return: MarshalAs(UnmanagedType.Bool)]
			[DllImport(DllNames.User32, EntryPoint="SetForegroundWindow")]
			private static extern Boolean TrySetForegroundWindowNative(WindowHandle hWnd);
			
			// It is clear for everyone, that the return value should be checked.
			public static Boolean TrySetForegroundWindow(WindowHandle hWnd)
			{
				if (hWnd == null)
					throw new ArgumentNullException(paramName: nameof(hWnd));
					
				return TrySetForegroundWindowNative(hWnd);
			}
			
			public static void SetForegroundWindow(WindowHandle hWnd)
			{
				if (hWnd == null)
					throw new ArgumentNullException(paramName: nameof(hWnd));
					
				var isSet = TrySetForegroundWindow(hWnd);
				if (!isSet)
					throw new InvalidOperationException(
						String.Format(
							"Failed to set foreground window {0}", 
							hWnd.DangerousGetHandle());
			}
		}
	
