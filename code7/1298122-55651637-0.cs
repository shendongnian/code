	using System;
	using System.Windows.Forms;
	namespace RichTextBoxFindWithReverse
	{
		static class ClsProgram
		{
			/// <summary>
			/// The main entry point for the application.
			/// </summary>
			[STAThread]
			static void Main()
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new ClsFormMain());
			}
		}
		/// <summary>
		/// https://stackoverflow.com/questions/1550293/stopping-textbox-flicker-during-update
		/// </summary>
		public static class ControlExtensions
		{
			[System.Runtime.InteropServices.DllImport("user32.dll")]
			public static extern bool LockWindowUpdate(IntPtr hWndLock);
			public static void Suspend(this Control control)
			{
				LockWindowUpdate(control.Handle);
			}
			public static void Resume(this Control control)
			{
				LockWindowUpdate(IntPtr.Zero);
			}
		}
	}
	
