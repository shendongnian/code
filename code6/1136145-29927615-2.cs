    public class MyClass : INotifyPropertyChanged
    {
            /// <summary>
            /// Event raised when a property changes.
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;
    
            /// <summary>
            /// Raises the PropertyChanged event.
            /// </summary>
            /// <param name="propertyName">The name of the property that has changed.</param>
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    }
