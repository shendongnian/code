     public class MainViewModel
    {
        private ViewModel1 _viewModel1 = new ViewModel1();
        private ViewModel2 _viewModel2 = new ViewModel2();
        public MainViewModel()
        {
            //event from ViewModel1 
            _viewModel1.SwitchViewModel2Request += NavigateToView2;
        }
        //switch View to ViewModel2
        private void NavigateToView2(object sender, EventArgs e)
        {
            CurrentViewModel = _viewModel2;
        }
    }
    public class ViewModel1
    {
        public ViewModel1()
        {
            ButtonOnViewModel1Command = new RelayCommand(Button1Method);
        }  
        //some button on child view 1
        public RelayCommand ButtonOnViewModel1Command { get; set; }
        private void Button1Method(object obj)
        {
            OnSwitchViewModel2Request();
        }
        //event that MainViewModel will subscribe to
        public event EventHandler SwitchViewModel2Request = delegate { };
        private void OnSwitchViewModel2Request()
        {
            SwitchViewModel2Request(this, EventArgs.Empty);
        }
    }
