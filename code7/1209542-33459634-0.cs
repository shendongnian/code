    using Windows.UI.ViewManagement;
    namespace yourNameSpace
    {
        sealed partial class App : Application
        {
            public App()
            {
                this.InitializeComponent();
                ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            }
        }
    }
