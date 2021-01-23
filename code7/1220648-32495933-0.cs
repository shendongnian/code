    public class Movie : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public ImageSource Picture { get; set; }
    }
