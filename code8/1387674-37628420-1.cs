	using System;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			public enum HookType : int
			{
				WH_JOURNALRECORD = 0,
				WH_JOURNALPLAYBACK = 1,
				WH_KEYBOARD = 2,
				WH_GETMESSAGE = 3,
				WH_CALLWNDPROC = 4,
				WH_CBT = 5,
				WH_SYSMSGFILTER = 6,
				WH_MOUSE = 7,
				WH_HARDWARE = 8,
				WH_DEBUG = 9,
				WH_SHELL = 10,
				WH_FOREGROUNDIDLE = 11,
				WH_CALLWNDPROCRET = 12,
				WH_KEYBOARD_LL = 13,
				WH_MOUSE_LL = 14
			}
			[StructLayout(LayoutKind.Sequential)]
			public struct POINT
			{
				public int X;
				public int Y;
			}
			[StructLayout(LayoutKind.Sequential)]
			public struct MouseHookStruct
			{
				public POINT pt;
				public int hwnd;
				public int hitTestCode;
				public int dwExtraInfo;
			}
			[DllImport("user32.dll", SetLastError = true)]
			static extern int SetWindowsHookEx(HookType hook, HookProc callback, IntPtr hInstance, uint dwThreadId);
			[DllImport("user32.dll", SetLastError = true)]
			static extern int CallNextHookEx(int hook, int code, IntPtr wParam, IntPtr lParam);
			[DllImport("kernel32.dll")]
			static extern int GetCurrentThreadId();
			public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
			private static int _hHook;
			private readonly Timer _timer1;
			public Form1()
			{
				InitializeComponent();
				_timer1 = new Timer();
                // setting the interval to 5000 is a lot easier than counting up to 5 ;)
				_timer1.Interval = 5000;
				_timer1.Tick += Timer1OnTick;
			}
			private void Form1_Load(object sender, EventArgs e)
			{
                // hook up to mouse events (or keyboard with WH_KEYBOARD)
                _hHook = SetWindowsHookEx(HookType.WH_MOUSE, MouseHookProc, IntPtr.Zero, (uint)GetCurrentThreadId());
				_timer1.Start();
			}
            // This function will get called every time there is a mouse event
			private int MouseHookProc(int code, IntPtr wParam, IntPtr lParam)
			{
                // Mouse event --> reset Timer
				_timer1.Stop();
				_timer1.Start();
				return CallNextHookEx(_hHook, code, wParam, lParam);
			}
            // 5000 ms without any mouse events --> show message
			private void Timer1OnTick(object sender, EventArgs eventArgs)
			{
                //Stop timer, Show message, start timer
				_timer1.Stop();
				MessageBox.Show("You have been idle for " + _timer1.Interval + " ms!");
				_timer1.Start();
			}
		}
	}
