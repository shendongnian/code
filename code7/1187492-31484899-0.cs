    namespace Project1
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                Class1 = new Class1();
                Class1.Class2.TextToBind = "Test";
                this.DataContext = this;
            }
            public Class1 Class1 { get; set; }
        }
    }
