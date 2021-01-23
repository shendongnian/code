    public class MainWindowViewModel
    {
        private IDialogService _dialogService;
        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            SaveCommand = new DelegateCommand(Save);
        }
        //implement PropertyChanged if needed
        public string SomeInput { get; set; }
        public DelegateCommand SaveCommand { get; private set; }
        private void Save()
        {
            var tableViewModel = new TableViewModel();
            tableViewModel.SomeInput = this.SomeInput;
            _dialogService.ShowModal(new DialogOptions
            {
                Title = "Table view",
                Content = tableViewModel 
            });
        }
    }
