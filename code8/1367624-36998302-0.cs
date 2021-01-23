    public interface IHomeView { }
    public interface IPresenter<TView> {
        TView View { get; set; }
    }
    public class HomeView : Form, IHomeView
    {
        private readonly IPresenter<IHomeView> presenter;
        public HomeView(IPresenter<IHomeView> presenter) {
            this.presenter = presenter;
            InitializeComponent();
        }
    }
