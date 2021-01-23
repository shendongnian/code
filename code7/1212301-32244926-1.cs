    //------------------------------
    //this sample code is taken from http://pinvoke.net/default.aspx/user32/EnumWindows.html
    public delegate bool EnumedWindow(IntPtr handleWindow, ArrayList handles);
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumWindows(EnumedWindow lpEnumFunc, ArrayList lParam);
    public static ArrayList GetWindows()
    {    
        ArrayList windowHandles = new ArrayList();
        EnumedWindow callBackPtr = GetWindowHandle;
        EnumWindows(callBackPtr, windowHandles);
        return windowHandles;     
    }
    private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
    {
        windowHandles.Add(windowHandle);
        return true;
    }
    //------------------------------
    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, [In,Out] ref Rect rect);
    [StructLayout(LayoutKind.Sequential)]
    private struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    static void Main() {
        foreach(IntPtr handle in GetWindows())
        {
          Screen scr = Screen.FromHandle(handle);
          if(IsFullscreen(handle, scr))
          {
              // the window is fullscreen...
          }
        }
    }
    private bool IsFullscreen(IntPtr wndHandle, Screen screen)
    {
        Rect r = new Rect();
        GetWindowRect(wndHandle, ref r);
        return new Rectangle(r.Left, r.Top, r.Right-r.Left, r.Bottom-r.Top)
                              .Contains(screen.Bounds);
    }
