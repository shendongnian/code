    public class TruckItems : INotifyPropertyChanged
    {
        private int _truckQuoteId;
 
        public int TruckQuoteId
        {
            get { return _truckQuoteId; }
            set
            {
                if(value != _truckQuoteId)
                {
                    value = _truckQuoteId;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TruckQuoteId));
                }
            }
        }
 
        public event PropertyChangedEventHandler PropertyChanged;
    }
 
