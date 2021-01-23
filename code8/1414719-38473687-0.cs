    public sealed partial class MainPage : Page
    {
        //define a public static property represent the MainPage itself
        public static MainPage Main { get; set; }
    
        public List<Icon> CategoryIcons { get; set; }
    
        public MainPage()
        {
            this.InitializeComponent();
            ///initialize Main property
            Main = this;
        }
    
        ...
    }
