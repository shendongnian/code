    public class MainWindowViewModel : IDialogViewModel
    {
        public OpenWindowCommand OpenWindowCommand { get; private set; }
        public ShowDialogCommand ShowDialogCommand { get; private set; }
        public MainWindowViewModel()
        {
            OpenWindowCommand = new OpenWindowCommand();
            ShowDialogCommand = new ShowDialogCommand(this);
        }
        public void PreOpenDialog()
        {
            throw new NotImplementedException();
        }
        public void PostOpenDialog(bool? dialogResult)
        {
            throw new NotImplementedException();
        }
    }
