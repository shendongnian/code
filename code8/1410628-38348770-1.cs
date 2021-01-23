    internal static class NativeMethods
    {
        public const Int32 MONITOR_DEFAULTTOPRIMERTY = 0x00000001;
		public const Int32 MONITOR_DEFAULTTONEAREST = 0x00000002;
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern IntPtr MonitorFromWindow(IntPtr handle, Int32 flags);
	}
