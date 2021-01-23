        public class MainForm: Form,IMainView
        {
            public event Action ButtonClicked;
            public MainForm()
            {
                InitializeComponent();
                button.Click += (sender, args) => 
                {
                    var handler = ButtonClicked;
                    if (handler != null) handler(sender, args);
                };
            }
            public void ShowError(string message)
            {
                MessageBox.Show(message);
            }
        }
        public interface IMainView : IView
        {
            event Action ButtonClicked;
        }
        public interface IView
        {
            void ShowError(string message);
        }
        public class MainPresenter : BasePresenter<IMainView>
        {
            public MainPresenter(IMainView view)
                : base(view)
            {
                view.ButtonClicked += view_ButtonClicked;
            }
            void view_ButtonClicked()
            {
                View.ShowError("Clicked!");
            }
        }
        public abstract class BasePresenter<TView> : IPresenter
            where TView : IView
        {
            protected TView View { get; private set; }
            protected BasePresenter(TView view)
            {
                View = view;
            }
        }
        public interface IPresenter
        {
        }
