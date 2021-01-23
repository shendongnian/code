    public partial class AwesomeView : TabbedPage
    {
        public AwesomeView()
        {
            InitializeComponent();
            BindingContext = new AwesomeViewModel();
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<AwesomeViewModel, int>(this, "SetActiveTab", (sender, index) => {
                CurrentPage = Children[index];
            });
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<AwesomeViewModel>(this, "SetActiveTab");
        }
    }
