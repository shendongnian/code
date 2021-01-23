	public class Window
	{
		public IntPtr Handle;
		public string Title;
		public int ProcessId;
		public bool Visible
		{
			get
			{
				return IsWindowVisible(Handle);
			}
		}
		public FormWindowState WindowState
		{
			get
			{
				WindowPlacement winp = new WindowPlacement();
				winp.Length = Marshal.SizeOf(winp);
				GetWindowPlacement(Handle, ref winp);
				return (FormWindowState)(winp.ShowCmd - 1);
			}
			set
			{
				ShowWindowAsync(Handle, (int)value + 1);
			}
		}
		public Window(IntPtr handle)
		{
			Handle = handle;
		}
		public void Close()
		{
			PostMessage(Handle, 0x10, 0, 0);
		}
		public void SetTitle(string title)
		{
			SetWindowText(Handle, title);
		}
		public static Window[] GetAllWindows()
		{
			List<Window> list = new List<Window>();
			EnumWindows(delegate(IntPtr hWnd, int lParam)
			{
				try
				{
					StringBuilder title = new StringBuilder(256);
					GetWindowText(hWnd, title, 256);
					Window window = new Window(hWnd);
					window.Title = title.ToString();
					GetWindowThreadProcessId(hWnd, out window.ProcessId);
					lock (list) list.Add(window);
				}
				catch { }
				return true;
			}, 0);
			return list.ToArray();
		}
		private struct Rect
		{
			int Left, Top, Right, Bottom;
		}
		private struct Point
		{
			int X, Y;
		}
		private struct WindowPlacement
		{
			public int Length, Flags, ShowCmd;
			public Point ptMinPosition, ptMaxPosition;
			public Rect rcNormalPosition;
		}
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		private static extern bool SetWindowText(IntPtr hWnd, string strNewWindowName);
		[DllImport("user32.dll")]
		private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);
		private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);
		[DllImport("user32.dll")]
		private static extern bool IsWindowVisible(IntPtr hWnd);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);
		[DllImport("user32.dll")]
		private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
		[DllImport("user32.Dll")]
		private static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
	}
