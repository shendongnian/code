    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Result> resultTest { get; private set; }
        public MainPage()
        {
            resultTest = new ObservableCollection<Result>();
            resultTest.Add(new Result() { title = "Hello" });
            resultTest.Add(new Result() { title = "World" });
            this.DataContext = this;
            this.InitializeComponent();
        }
    }
