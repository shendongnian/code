    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetDefaultStyle();
            MainPage = new TestPage();
        }
        public void SetDefaultStyle()
        {
            Resources = Default;
        }
        public void SetSecondStyle()
        {
            Resources = Second;
        }
    }
