    public class YourViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ImageSource barCodeImage;
        public ImageSource BarCodeImage
        {
            get { return barCodeImage; }
            set
            {
                barCodeImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BarCodeImage"));
            }
        }
        ...
    }
