        public MainWindow()
        {
            InitializeComponent();
            dockingManager.LayoutUpdated += DockingManager_LayoutUpdated;
        }
        private void DockingManager_LayoutUpdated(object sender, EventArgs e)
        {
            var q = FindVisualChild<Xceed.Wpf.AvalonDock.Controls.DocumentPaneTabPanel>(dockingManager);
            if (q != null)
            {
                q.FlowDirection = FlowDirection.RightToLeft;
                dockingManager.LayoutUpdated -= DockingManager_LayoutUpdated;
            }
        }
        public T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
