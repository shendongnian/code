    public class MainWindow : Window
    {
        WorkSpaceView ws;
        public MainWindow()
            : base()
        {
            ws = new WorkSpaceView();
            this.Content = ws;
        }
    }
