    public class YourViewModel
    {
        //commands
        public ICommand someCommand { get; set; }
    
        private IDialogWindowService<BookingView> _dialogService;
        public YourViewModel(IDialogWindowService<YourView > dialogService)
        {
            _dialogService = dialogService
            someCommand = new RelayCommand(someCommandDoJob, () => true);
        }
    
        public void someCommandDoJob(object obj)
        {
            //Since you want to launch this view as dialog you can set its datacontext in its own constructor.    
            _dialogService.ShowDialog();
        }
    }
