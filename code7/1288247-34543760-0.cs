    public class Image
    {
        public int Id {get; set; }
        public Uri Url { get; set; }
    }
    public class Album
    {
        public ObservableCollection<int> ImageIds {get; set; }
    }
    public DataSource()
    {
        _imageCollection = new ObservableCollection<Image>();
        _albumCollection= new ObservableCollection<Album>();
    }
