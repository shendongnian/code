    public interface IPlayerLauncher
    {
        void Launch(string fileName);
    }
    
    public interface IDialogService
    {
        void ShowMessageBox(string message);
    }
    
    public class SomeViewModel
    {
        private readonly IPlayerLaucher playerLauncher;
        private readonly IDialogService dialogService;
    
        private void HandleOpenVideo()
        { 
            try
            {
                playerLauncher.Launch("Instructional_Video.wmv");
            }
            catch
            {
                dialogService.ShowMessageBox("Error playing instructional video");            
            }
        }
    
        public SomeViewModel(IPlayerLaucher playerLaucher, IDialogService dialogService)
        {
            this.playerLauncher = playerLauncher;
            this.dialogService = dialogService;
            OpenVideoCommand = new RelayCommand(HandleOpenVideo);
        }
    
        public ICommand OpenVideoCommand { get; }
    }
    public class PlayerLaucher : IPlayerLauncher
    {
        public void Lauch(string fileName)
        {
            Process.Start(fileName);
        }
    }
    public class DialogService : IDialogService
    {
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    } 
