    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private FileDataSource _PicturesCollection;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public FileDataSource PicturesCollection
        {
            get
            {
                return _PicturesCollection;
            }
            set
            {
                if (_PicturesCollection != value)
                {
                    _PicturesCollection = value;
                    NotifyPropertyChanged();
                }
            }
        }
    
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ...
        private async void initdata()
        {
            StorageLibrary pictures = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Pictures);
            string path = pictures.SaveFolder.Path;
            var source = await FileDataSource.GetDataSoure(path);
            if (source.Count > 0)
            {
                PicturesCollection = source;
            }
        }
    }
