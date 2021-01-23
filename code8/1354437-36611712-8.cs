    [Flags]
    enum MouseEventFlags : uint
    {
        MOUSEEVENTF_MOVE = 0x0001,
        MOUSEEVENTF_LEFTDOWN = 0x0002,
        MOUSEEVENTF_LEFTUP = 0x0004,
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        MOUSEEVENTF_RIGHTUP = 0x0010,
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        MOUSEEVENTF_XDOWN = 0x0080,
        MOUSEEVENTF_XUP = 0x0100,
        MOUSEEVENTF_WHEEL = 0x0800,
        MOUSEEVENTF_VIRTUALDESK = 0x4000,
        MOUSEEVENTF_ABSOLUTE = 0x8000
    }
    [DllImport("user32.dll")]
    public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
    [DllImport("user32")]
    public static extern int SetCursorPos(int x, int y);
    [DllImport("USER32.DLL")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    private static bool WindowActive(string keys, IntPtr handle)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// checks for the currently active window then simulates a mouseclick
    /// </summary>
    /// <param name="button">which button to press (left middle up)</param>
    /// <param name="windowName">the window to send to</param>
    public static void MouseClick(string button, string windowName)
    {
        switch (button)
        {
            case "left":
                mouse_event((uint)MouseEventFlags.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event((uint)MouseEventFlags.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                break;
            case "right":
                mouse_event((uint)MouseEventFlags.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                mouse_event((uint)MouseEventFlags.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                break;
            case "middle":
                mouse_event((uint)MouseEventFlags.MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
                mouse_event((uint)MouseEventFlags.MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
                break;
        }
    }
    /// <summary>
    /// moves a window and resizes it accordingly
    /// </summary>
    /// <param name="x">x position to move to</param>
    /// <param name="y">y position to move to</param>
    /// <param name="windowName">the window to move</param>
    /// <param name="width">the window's new width</param>
    /// <param name="height">the window's new height</param>
    public static void WindowMove(int x, int y, string windowName, int width, int height)
    {
        IntPtr window = FindWindow(null, windowName);
        if (window != IntPtr.Zero) { MoveWindow(window, x, y, width, height, true); }
    }
    /// <summary>
    /// moves a window to a specified position
    /// </summary>
    /// <param name="x">x position</param>
    /// <param name="y">y position</param>
    /// <param name="windowName">the window to be moved</param>
    public static void WindowMove(int x, int y, string windowName)
    {
        WindowMove(x, y, windowName, 800, 600);
    }
    public static void LeftClick(int x, int y)
    {
        Cursor.Position = new System.Drawing.Point(x, y);
        mouse_event((int)(MouseEventFlags.MOUSEEVENTF_LEFTDOWN), 350, 150, 0, 0);
        mouse_event((int)(MouseEventFlags.MOUSEEVENTF_LEFTUP), 350, 150, 0, 0);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        WindowMove(200, 200, "Form1", 400, 400);
        SetCursorPos(350, 150);
        LeftClick(350, 150); // your function
        MouseClick("button1", "Form1");
    }
