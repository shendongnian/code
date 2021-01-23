        {
            InitializeComponent();
            var activeWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(win=>win.IsActive);
            if(activeWindow != null)
            {
                this.Top = activeWindow.Top;
                this.Left = activeWindow.Left;
            }
        }
