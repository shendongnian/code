        [DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetCursorPos(ref System.Drawing.Point lpPoint);
		public static System.Drawing.Point GetCursorPosition()
		{
			System.Drawing.Point p = new System.Drawing.Point(0, 0);
			GetCursorPos(ref p);
			return p;
		}
