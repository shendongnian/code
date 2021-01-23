    public partial class Home : ContentPage
    {
        public Home ()
        {
            InitializeComponent ();
            this.BindingContext = new TestPageVM();
        }
    }
