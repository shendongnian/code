    public partial class MainWindow : Window
    {
        public Page1 Page1Ref = null;
        public Page1 Page2Ref = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Frame1.Source = new Uri("/Source/Pages/Page1.xaml", UriKind.Relative);
            Frame1.ContentRendered += Frame1_ContentRendered;
           
            // do the same for the Frame2
        }
        private void Frame1_ContentRendered(object sender, EventArgs e)
        {
            var b = Frame1.Content as Page1; // Is now Home.xaml
            Page1Ref = b;
            if(Page2Ref != null) // because you don't know which of the pages gets rendered first
            {
               Page2Ref.Page1Ref = Page1Ref; // add the Page1Ref prop to your Page2 class 
               Page1Ref.Page2Ref = Page2Ref;  // here the same
            }
            
        }
        // do the same for the other page
    }
