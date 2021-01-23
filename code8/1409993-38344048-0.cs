    public sealed partial class HomePage : Page
    {
        //define a static field represent the HomePage itself
        public static HomePage Home;
        public HomePage()
        {
            this.InitializeComponent();
            //initialize Home field
            Home = this;
        }
        ...
        /// <summary>
        /// Show some message in TextBlock lblClassName
        /// </summary>
        /// <param name="message">message to been shown</param>
        public void ChangeMessage(string message)
        {
            this.lblClassName.Text = message;
        }
    }
