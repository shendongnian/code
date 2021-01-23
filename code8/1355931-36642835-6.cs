    public class MenuViewModel : IViewMainWindowViewModel
    {
        //commands
        public ICommand bookingCommand { get; set; }
        
        private IDialogService<BookingView> _dialogService;
        public MenuViewModel(IDialogService<BookingView > dialogService)
        {
            _dialogService = dialogService
            bookingCommand = new RelayCommand(bookingCommand_DoWork, () => true);
        }
    
        public void bookingCommand_DoWork(object obj)
        {
            //Since you want to launch this view as dialog you can set its datacontext in its own constructor.
    
            _dialogService.ShowDialog();
        }
    }
