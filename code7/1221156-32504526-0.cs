    public class ShellViewModel : INotifyPropertyChanged
        {
            private ICommand _changeViewModelCommand;
    
            private object _currentViewModel;
            private List<object> _viewModels = new List<object>();
    
            public ShellViewModel()
            {
                ViewModels.Add(new HomeViewModel());
                CurrentViewModel = ViewModels[0];
            }
    
            private void ChangeViewModel(object viewModel)
            {
                if (!ViewModels.Contains(viewModel))
                    ViewModels.Add(viewModel);
    
                CurrentViewModel = ViewModels.FirstOrDefault(vm => vm == viewModel);
            }
        }
