    public class SalesViewModel : INotifyPropertyChanged
    {
        private PlotModel _plotModel;
    
        public PlotModel PlotModel
        {
            get { return _plotModel; }
            set {
                _plotModel = value;
                RaisePropertyChanged();
            }
        }
    
        // other methods here that create your model
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler (this, new PropertyChangedEventArgs (propertyName));
        }
    }
