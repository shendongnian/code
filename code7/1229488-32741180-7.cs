    public class MainWindowViewModel
    {
        public OpenWindowCommand OpenWindowCommand { get; private set; }
        public ShowDialogCommand ShowDialogCommand { get; private set; }
        public MainWindowViewModel()
        {
            OpenWindowCommand = new OpenWindowCommand();
            ShowDialogCommand = new ShowDialogCommand(PostOpenDialog);
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
