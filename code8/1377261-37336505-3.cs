    class MyToolBar : ToolBar
    {
        public NoOverflowToolBar()
            : base()
        {
            this.Loaded += MyToolBar_Loaded;
        }
        void MyToolBar_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var grid = toolBar.Template.FindName("Grid", toolBar) as FrameworkElement;
            if (grid != null)
            {
                grid.Margin = new Thickness(3, 1, -3, 1);
            }
        }
    }
