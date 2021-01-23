    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return this.currentViewModel;
            }
            set
            {
                this.currentViewModel = value;
                this.RaisePropertyChanged("CurrentViewModel");
            }
        }
        public RelayCommand SwitchToBaseCommand
        {
            get
            {
                return new RelayCommand(() => SwitchToBase());
            }
        }
        public RelayCommand SwitchToNavigationCommand
        {
            get
            {
                return new RelayCommand(() => SwitchToNavigation());
            }
        }
        public void SwitchToBase()
        {
            CurrentViewModel = ServiceLocator.Current.GetInstance<BaseViewModel>();
        }
        public void SwitchToNavigation()
        {
            CurrentViewModel = ServiceLocator.Current.GetInstance<NavigationViewModel>();
        }
    }
