    public class MyObservableCollection<T> : ObservableCollection<T>
    {
        private string _convertedText;
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            this.ConvertedText = ...; // <- do here what your IValueConverter does
        }
        public string ConvertedText
        {
            get { return _convertedText; }
            private set
            {
                _convertedText = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ConvertedText"));
            }
        }
    }
