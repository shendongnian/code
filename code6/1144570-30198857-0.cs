    public class FlowManager
    {
        private static FlowManager _instance;
        private MainWindow _mainWindow;
        private ICollection<IViewModel> _viewModels; 
        private FlowManager()
        {
            ViewModels = new List<IViewModel>();
        }
        public void ChangePage<TViewModel>() where TViewModel : IViewModel, new()
        {
            // If we are already on the same page as the button click, we don't change anything
            if (AppWindow.ViewModel.CurrentViewModel == null || 
                AppWindow.ViewModel.CurrentViewModel.GetType() != typeof(TViewModel))
            {
                foreach (IViewModel viewModel in ViewModels)
                {
                    // If an instance of the viewmodel already exists, we switch to that one
                    if (viewModel.GetType() == typeof(TViewModel))
                    {
                        AppWindow.ViewModel.CurrentViewModel = viewModel;
                        return;
                    }
                }
            
                // Else, we create a new instance of the viewmodel
                TViewModel newViewModel = new TViewModel();
                AppWindow.ViewModel.CurrentViewModel = newViewModel;
                ViewModels.Add(newViewModel);
            }
        }
        public static FlowManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FlowManager();
                }
                return _instance;
            }
        }
        public MainWindow AppWindow { get; set; }
        public ICollection<IViewModel> ViewModels { get; private set; }
    }
