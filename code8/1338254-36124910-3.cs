	public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.boundControl.DataContext = new VMTest
            {
                IsTrue = true,
                FalseValueDefined = "False Value (Binding)",
                TrueValueDefined = "True Value (Binding)"
            };
        }
    }
