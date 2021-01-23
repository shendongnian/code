    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = new MainViewModel(() => (new Window()).Show()); // would be actual window
        }
    }
    
    public class MainViewModel
    {
        private Action popupAction;
        public MainViewModel(Action popupAction)
        {
            this.popupAction = popupAction;
        }
    
        public ICommand PopupCommand { get; set; }
    
        public void PopupCommandAction()
        {
            popupAction();
        }
    }
    
    public class SomeUnitTest
    {
        public void TestVM()
        {
            var vm = new MainViewModel(() => { });
        }
    }
