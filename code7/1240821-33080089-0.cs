    public MainWindow()
    {
        InitializeComponent();
        this.MouseRightButtonDown += MainWindow_MouseRightButtonDown;
    }
    
    private void MainWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        MenuUserControl.ToggleIsCollapsed();
    }
    
    public partial class MenuUserControl
    {
        public static void ToggleIsCollapsed()
        {
            // do your stuff
        }
    }
