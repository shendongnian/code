        public class BrowserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double optimalWidth;
        private double optimalHeight;
        public double OptimalWidth
        {
            get { return this.optimalWidth;}
            set
            {
                if (this.optimalWidth != value)
                {
                    this.optimalWidth = value;
                    NotifyPropertyChanged("OptimalWidth");
                }
            }
        }
        public double OptimalHeight
        {
            get { return this.optimalHeight; }
            set
            {
                if (this.optimalHeight != value)
                {
                    this.optimalHeight = value;
                    NotifyPropertyChanged("OptimalHeight");
                }
            }
        }
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
