    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	public static class MouseHook
    	{
    		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    		private static extern IntPtr SetWindowsHookEx(int idHook,
    					LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    		[return: MarshalAs(UnmanagedType.Bool)]
    		private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    
    		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    		private static extern IntPtr GetModuleHandle(string lpModuleName);
    
    		private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    
    		private const int WH_MOUSE_LL = 14;
    
    		private static IntPtr SetHook(LowLevelMouseProc proc)
    		{
    			using (Process curProcess = Process.GetCurrentProcess())
    			using (ProcessModule curModule = curProcess.MainModule)
    			{
    				return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
    			}
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		private struct POINT
    		{
    			public int x;
    			public int y;
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		private struct MSLLHOOKSTRUCT
    		{
    			public POINT pt;
    			public uint mouseData;
    			public uint flags;
    			public uint time;
    			public IntPtr dwExtraInfo;
    		}
    
    		private enum MouseMessages
    		{
    			WM_LBUTTONDOWN = 0x0201,
    			WM_LBUTTONUP = 0x0202,
    			WM_MOUSEMOVE = 0x0200,
    			WM_MOUSEWHEEL = 0x020A,
    			WM_RBUTTONDOWN = 0x0204,
    			WM_RBUTTONUP = 0x0205
    		}
    
    		private static IntPtr _hookID = IntPtr.Zero;
    
    		public static void Register()
    		{
    			if (_hookID != IntPtr.Zero) return;
    			_hookID = SetHook(HookCallback);
    		}
    
    		public static void Unregister()
    		{
    			if (_hookID == IntPtr.Zero) return;
    			UnhookWindowsHookEx(_hookID);
    			_hookID = IntPtr.Zero;
    		}
    
    		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    		{
    			if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
    			{
    				var handler = LButtonDown;
    				if (handler != null) handler(null, EventArgs.Empty);
    			}
    			return CallNextHookEx(_hookID, nCode, wParam, lParam);
    		}
    
    		public static event EventHandler LButtonDown;
    	}
    	// Test
    	class TestForm : Form
    	{
    		Label label;
    		protected override void OnLoad(EventArgs e)
    		{
    			Controls.Add(label = new Label());
    			MouseHook.LButtonDown += OnHookLButtonDown;
    			base.OnLoad(e);
    		}
    		protected override void OnFormClosed(FormClosedEventArgs e)
    		{
    			MouseHook.LButtonDown -= OnHookLButtonDown;
    		}
    		private void OnHookLButtonDown(object sender, EventArgs e)
    		{
    			var pt = Control.MousePosition;
    			label.Text = "{" + pt.X + ", " + pt.Y + "}";
    		}
    	}
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			MouseHook.Register();
    			try { Application.Run(new TestForm()); }
    			finally { MouseHook.Unregister(); }
    		}
    	}
    }
