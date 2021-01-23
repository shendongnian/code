    public sealed partial class MainBrowser : Page, INotifyPropertyChanged
    {
        // Backing field.
        private ObservableCollection<Item> fileInCurrentFolderListUI;
        // Property.
        public ObservableCollection<Item> FileInCurrentFolderListUI
        {
            get { return fileInCurrentFolderListUI; }
            set
            {
                if (value != fileInCurrentFolderListUI)
                {
                    fileInCurrentFolderListUI = value;
                    // Notify of the change.
                    NotifyPropertyChanged();
                }
            }
        }
        // PropertyChanged event.
        public event PropertyChangedEventHandler PropertyChanged;
        // PropertyChanged event triggering method.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
