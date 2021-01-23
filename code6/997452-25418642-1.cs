    /// <summary>
	/// Class containing helper functions for wpf interoperability 
	/// </summary>
	public static class WpfInteropHelper
	{
		private const int WMSETREDRAW = 0x000B;
		/// <summary>
		/// Suspends the specified control.
		/// </summary>
		/// <param name="control">The control.</param>
		public static void Suspend(Control control)
		{
			Message msgSuspendUpdate = Message.Create(control.Handle, WMSETREDRAW, IntPtr.Zero, IntPtr.Zero);
			NativeWindow window = NativeWindow.FromHandle(control.Handle);
			window.DefWndProc(ref msgSuspendUpdate);
		}
		/// <summary>
		/// Resumes the specified control.
		/// </summary>
		/// <param name="control">The control.</param>
		public static void Resume(Control control)
		{
			control.Visible = false;
			var wparam = new IntPtr(1);
			Message msgResumeUpdate = Message.Create(control.Handle, WMSETREDRAW, wparam, IntPtr.Zero);
			NativeWindow window = NativeWindow.FromHandle(control.Handle);
			if (window != null) {
				window.DefWndProc(ref msgResumeUpdate);
			}
			control.Invalidate();
			control.Visible = true;
		}
	}
