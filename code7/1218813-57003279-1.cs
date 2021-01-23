    namespace YourAppName
    {
        public partial class MainWindow : Window
        {
            public delegate Point GetPosition(IInputElement element);
            int rowIndex = -1;
            string dgName;
            public MainWindow()
            {
                dg1.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DgSupp_PreviewMouseLeftButtonDown);
                dg1.Drop += new DragEventHandler(Dg_Drop);
                dg2.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DgSupp_PreviewMouseLeftButtonDown);
                dg2.Drop += new DragEventHandler(Dg_Drop);
            }
