     public class MainViewModel : ViewModelBase
        {
            public ObservableCollection<ViewModelBase> ViewModels { get; set; } = new ObservableCollection<ViewModelBase>();
    
            private ViewModelBase _currentViewModel;
    
            public ViewModelBase CurrentViewModel {
                get { return _currentViewModel; }
                set { SetField(ref _currentViewModel, value); }
            }
    
            private ICommand _nextViewModel;
            public ICommand NextViewModel
            {
                get
                {
                    return _nextViewModel = _nextViewModel ?? new RelayCommand(p =>
                      {
                          CurrentViewModel = ViewModels[ViewModels.IndexOf(CurrentViewModel) +1];
                      }, p =>
                      {
                          return ViewModels.IndexOf(CurrentViewModel) + 1 != ViewModels.Count && CurrentViewModel != null;
                      });
                }
            }
    
            public ICommand _prevViewModel;
            public ICommand PrevViewModel
            {
                get
                {
                    return _prevViewModel = _prevViewModel ?? new RelayCommand(p =>
                    {
                        CurrentViewModel = ViewModels[ViewModels.IndexOf(CurrentViewModel) - 1];
                    }, p =>
                    {
                        return ViewModels.IndexOf(CurrentViewModel) != 0 && CurrentViewModel!=null;
                    });
                }
            }
    
            private ICommand _switchToViewModel;
            public ICommand SwitchToViewModel
            {
                get
                {
                   return _switchToViewModel = _switchToViewModel ?? new RelayCommand(p =>
                    {
                        CurrentViewModel = this.ViewModels.FirstOrDefault(vm=>vm.GetType()==p as Type);
                    }, p =>
                    {
                        return this.ViewModels.FirstOrDefault(vm => vm.GetType() != p as Type) != null;
                    });
                }
            }
        } 
