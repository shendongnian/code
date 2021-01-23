    public class MarketDataViewModelBase : IMarketDataViewModel, INotifyPropertyChanged
    {
        .....
 
        private ObservableCollection<IMarketDataViewModel> items;
        public ObservableCollection<IMarketDataViewModel> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("Items"); //Add this line fix my issue
            }
        }
     }
