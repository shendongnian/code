        //Your MainForm class
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
        //Your MainForm interface. What lies here will become accessible in Presenter
        public interface IMainView : IView
        {
            event Action ButtonClicked;
        }
        //View interface
        public interface IView
        {
            void ShowError(string message);
        }
        
        //Your MainForm Presenter class which will do all work behind GUI
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
        //Base class for all presenters
        public abstract class BasePresenter<TView> : IPresenter
            where TView : IView
        {
            protected TView View { get; private set; }
            protected BasePresenter(TView view)
            {
                View = view;
            }
        }
        //Presenter interface
        public interface IPresenter
        {
        }
