    using Microsoft.Advertising.Mobile.UI;
    namespace WP_AdApp
    {
    public partial class MainPage : PhoneApplicationPage
    {
        private AdControl adControl;
        private const string APPLICATION_ID = "e1e3c23b-3a59-4119-852e-8ad0a7f78f11";
        private const string AD_UNIT_ID = "10020750";
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }
        private void OnAdError_ErrorOccurred(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {
            MessageBox.Show("AdControl error: " + e.Error.Message);
        }
    }
    }
