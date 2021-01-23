    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
    
            if (this.CanSetScreenCaptureEnabled())
            {
                this.SetScreenCaptureEnabled(false);
            }
        }
    }
