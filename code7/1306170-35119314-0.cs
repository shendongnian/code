    public sealed partial class MainPage : Page
    {
         public MainPage()
         {
         this.InitializeComponent();
    
         // Set the preferred launch view size to 360 * 550
         ApplicationView.PreferredLaunchViewSize = new Size { Height = 550, Width = 360 };
         ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
         }
    }
