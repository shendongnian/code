    public sealed partial class MainPage : Page 
    {
        ViewModelexample obj = null;
        public MainPage()
        {
            this.InitializeComponent();
            obj = new ViewModelexample();
            this.DataContext = obj;        
        }
    
        public void OnSomeEventHandler() {
            obj.Method();
        }
    }
