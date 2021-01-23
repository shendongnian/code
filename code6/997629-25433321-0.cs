    public sealed partial class EditPage : Page
    {
        public EditPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter.ToString() == "Page1")
            {
                //Navigated from Page1
            }
           
            if(e.Parameter.ToString() == "Page2")
            {
                //Navigated from Page2
            }
        }
    }
