    // P/Invoke constants
    private const int WM_SYSCOMMAND = 0x112;
    private const int MF_STRING = 0x0;
    private const int MF_SEPARATOR = 0x800;
    // P/Invoke declarations
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool InsertMenu(IntPtr hMenu, int uPosition, int uFlags, int uIDNewItem, string lpNewItem);
    // ID for the About item on the system menu
    private int SYSMENU_ABOUT_ID = 0x1;
    public MainWindow()
    {
        InitializeComponent();
    }
    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        var source = (HwndSource) PresentationSource.FromVisual(this);
        source.AddHook(WndProc);
        var helper = new WindowInteropHelper(this);
        // Get a handle to a copy of this form's system (window) menu
        IntPtr hSysMenu = GetSystemMenu(helper.Handle, false);
        // Add a separator
        AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);
        // Add the About menu item
        AppendMenu(hSysMenu, MF_STRING, SYSMENU_ABOUT_ID, "&About…");
    }
    private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        // Handle messages...
        // Test if the About item was selected from the system menu
        if ((msg == WM_SYSCOMMAND) && ((int)wParam == SYSMENU_ABOUT_ID))
        {
            MessageBox.Show("Custom About Dialog");
        }
        return IntPtr.Zero;
    }
