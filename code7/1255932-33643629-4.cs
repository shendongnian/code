    public sealed partial class MyPage : BasePage
    {
        public sealed class MyViewModel : BaseViewModel
        {
            public string Title
            {
                get
                {
                    return "Test";
                }
            }
        }
        public MyPage()
        {
            InitializeComponent();
            ViewModel = new MyViewModel();
            this.DataContext = this;
        }
    }
