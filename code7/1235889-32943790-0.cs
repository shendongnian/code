    public class DynamicResources : ViewModelBase
    {
        private double verseFontSize;
        public double VerseFontSize
        {
            get { return verseFontSize; }
            set
            {
                verseFontSize = value;
                RaisePropertyChanged();
            }
        }
    }
