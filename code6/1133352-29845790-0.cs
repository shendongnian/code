    public class MyClass : INotifyPropertyChanged
        {
            private ICollectionView tasks;
            public ICollectionView Tasks
            {
                get
                {
                    return tasks;
                }
                set
                {
                    tasks = value;
                    OnPropertyChanged("Tasks");
                }
            }
    
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
