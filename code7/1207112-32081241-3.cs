    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            ChangeFileName = new DelegateCommand(OnChangeFileName);
        }
    
        public ICommand ChangeFileName { get; private set; }
    
        private void OnChangeFileName(object param)
        {
            FolderOrFileName = "FileName" + new Random().Next();
        }
    
        private string folderOrFileName;
        ...
