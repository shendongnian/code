    public sealed partial class MyPage : BasePage
    {
        public MyViewModel myViewModel;
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
            myViewModel = new MyViewModel();
        }
    }
