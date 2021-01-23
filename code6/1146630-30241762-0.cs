    public partial class MainWindow : Window
    {
        View v = new View();
        Edit e = new Edit();
    
        public MainWindow()
        {
            InitializeComponent();
    
            Window1.Viewer.Content = v;
            Window1.Editor.Content = e;
    
            EventManager.RegisterClassHandler(GetType(), Button.ClickEvent, new RoutedEventHandler(OnButtonClick));
        }
    
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (e.Source is View)
            {
                SwichToEditor();
            }
            else
            {
                SwichToViewer();
            }
        }
    
        public void SwichToEditor()
        {
            Window1.Editor.Visibility = System.Windows.Visibility.Visible;
            Window1.Viewer.Visibility = System.Windows.Visibility.Hidden;
        }
    
        public void SwichToViewer()
        {
            Window1.Ediort.Visibility = System.Windows.Visibility.Hidden;
            Window1.Viewer.Visibility = System.Windows.Visibility.Visible;
        }
    }
