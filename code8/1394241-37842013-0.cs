	public static class Keyboard
	{
		public static void Press(Keys keys, int sleep = 1)
		{
			var keyValue = (byte)keys;
		
			NativeMethods.keybd_event(keyValue, 0, 0, UIntPtr.Zero); //key down
			
			Thread.Sleep(sleep);
			
			NativeMethods.keybd_event(keyValue, 0, 0x02, UIntPtr.Zero); //key up
		}
	}
	internal static partial class NativeMethods
	{
		[DllImport("user32.dll")]
		internal static extern void keybd_event(byte bVk, byte bScan, int dwFlags, UIntPtr dwExtraInfo);
	}
