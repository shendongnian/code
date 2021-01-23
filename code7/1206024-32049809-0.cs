        public class ObservableChartDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyPropertyChanged
        {
            public void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            public TValue this[TKey key]
            {
                get { return this[key]; }
                set
                {
                    base[key]= value;
                    OnPropertyChanged(key.ToString());
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
