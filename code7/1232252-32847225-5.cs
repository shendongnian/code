     public class MainVm : ViewModelBase
      {
        private FirstVm _FirstViewModel;
        public FirstVm FirstViewModel
        {
          get { return _FirstViewModel; }
          set { Set(ref _FirstViewModel, value); }
        }
    
        private SecondVm _SecondViewModel;
        public SecondVm SecondViewModel
        {
          get { return _SecondViewModel; }
          set { Set(ref _SecondViewModel, value); }
        }
    
    
        private ViewModelBase _SelectedViewModel;
        public ViewModelBase SelectedViewModel
        {
          get { return _SelectedViewModel; }
          set { Set(ref _SelectedViewModel, value); }
        }
    
        public ICommand SelectFirstViewModel
        {
          get
          {
            return new RelayCommand(() => { this.SelectedViewModel = FirstViewModel; });
          }
        }
    
        public ICommand SelectSecondViewModel
        {
          get
          {
            return new RelayCommand(() => { this.SelectedViewModel = SecondViewModel; });
          }
        }
    
        public MainVm()
        {
          FirstViewModel = new FirstVm();
          SecondViewModel = new SecondVm();
          SelectedViewModel = this.FirstViewModel;
        }
      }
