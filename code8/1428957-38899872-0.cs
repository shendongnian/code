    public class ColorItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        public Brush ItemBrush => new SolidColorBrush(Color.FromRgb(R, G, B));
        byte _r;
        public byte R 
        {
            get { return _r; }
            set
            {
                _r = value;
                OnPropertyChanged(); // this will update bindings to R
                OnPropertyChanged(nameof(ItemBrush)); // this will update bindings to ItemBrush
            }
        }
        ... // same for G and B
    }
