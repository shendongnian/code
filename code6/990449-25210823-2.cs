    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;    
    using GalaSoft.MvvmLight.Messaging;
    // View
    public partial class TestActivateWindow : Window
    {
        public TestActivateWindow() {
            InitializeComponent();
            Messenger.Default.Register<ActivateWindowMsg>(this, (msg) => Activate());
        }
    }
    // View Model
    class ActivateWindowMsg
    {
    }
    public class MainViewModel: ViewModelBase
    {
        ICommand _activateChildWindowCommand;
        public ICommand ActivateChildWindowCommand {
            get {
                return _activateChildWindowCommand?? (_activateChildWindowCommand = new RelayCommand(() => {
                    Messenger.Default.Send(new ActivateWindowMsg());
            }));
            }
        }
    }
