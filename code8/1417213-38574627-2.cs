    public partial class Page3 : ContentPage
    {
        public MyViewModel vm { get; set; }
        public Page3()
        {
            InitializeComponent();
            vm = new MyViewModel();
            BindingContext = vm;
        }
    }
