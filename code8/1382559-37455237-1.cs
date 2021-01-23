    namespace MoballeghanPro.Client
    {
        public partial class frmSplashScreen : PerPixelAlphaForm
        {
            public frmSplashScreen()
            {
                InitializeComponent();
            }
    
            private void frmSplashScreen_Load(object sender, EventArgs e)
            {
                SetBitmap(Properties.Resources.IntroMobaleghan); //Png picture in the resources
                
            }
        }
    }
