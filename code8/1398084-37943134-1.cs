    class Foo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    // we're using CallerMemberName here
                    OnPropertyChanged();
                }
            }
        }
        public void Add(decimal value)
        {
            Amount += value;
            // we can't use CallerMemberName here, because it will be "Add";
            // instead of this we have to use "nameof" to tell, what property was changed
            OnPropertyChanged(nameof(Amount));
        }
        public decimal Amount { get; private set; }
    }
