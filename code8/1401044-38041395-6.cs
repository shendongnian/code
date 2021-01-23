    public class DataRowExt: DataRow, INotifyPropertyChanged
    {
        protected internal DataRowExt(DataRowBuilder builder) : base(builder)
        {
        }
        internal void OnRowStateChanged()
        {
            OnPropertyChanged("RowState");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
