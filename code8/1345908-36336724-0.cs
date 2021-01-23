    bool _start;
    public MainWindow()
    {
        InitializeComponent();
        ContextMenu = new ContextMenu();
        var menuItem = new MenuItem() { Header = "Launch notepad" };
        menuItem.Click += (s, e) => _start = true;
        ContextMenu.Items.Add(menuItem);
        ContextMenu.Closed += (s, e) =>
        {
            if (_start)
            {
                _start = false;
                using (var process = new Process() { StartInfo = new ProcessStartInfo("notepad.exe") { CreateNoWindow = false } })
                {
                    process.Start();
                    process.WaitForExit();
                }
            }
        };
    }
