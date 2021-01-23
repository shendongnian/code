     public sealed partial class BlankPage : Page
        {
            public Model MyModel = new Model() { Index = MainPage.MyModel.Index };
    
            public BlankPage()
            {
                this.InitializeComponent();
                this.Unloaded += (s, e) => { MainPage.MyModel.Index = MyModel.Index; Debug.WriteLine("--- page unloaded ---"); };
                DataContext = this;
            }
        }
