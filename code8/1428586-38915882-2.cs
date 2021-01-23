    public class SalesPerProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private PlotModel _salesPerProductModel;
        public PlotModel SalesPerProductModel
        {
            get
            {
                return _salesPerProductModel;
            }
            set
            {
                if (value != _salesPerProductModel)
                {
                    _salesPerProductModel = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SalesPerProductModel"));
                }
            }
        }
        public SalesPerProductViewModel()
        {
        }
    }
