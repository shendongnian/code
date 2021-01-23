    public sealed partial class BasicPage : Page
    {
        bool bAfterLoaded = false;
        public BasicPage()
        {
            this.InitializeComponent();
            this.Loaded += BasicPage_Loaded;
            this.LayoutUpdated += BasicPage_LayoutUpdated;
        }
        private void BasicPage_LayoutUpdated(object sender, object e)
        {
            if (bAfterLoaded)
            {
                Test1.Focus(FocusState.Programmatic);
                bAfterLoaded = !bAfterLoaded;
            }
        }
        private void BasicPage_Loaded(object sender, RoutedEventArgs e)
        {
            bAfterLoaded = !bAfterLoaded;
        }
    }
