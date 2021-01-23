    using System.ComponentModel;
    using System.Windows.Media;
    ...
    public class YourViewModel : INotifyPropertyChanged{
        ...
        private Brush _backgroundCol = Brushes.Red; //Default color
        public Brush BackgroundCol
        {
            get { return _backgroundCol; }
            set 
            {
                _backgroundCol = value;
                OnPropertyChanged("BackgroundCol");
            }
        }
        ...
    }
