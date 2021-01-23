    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace WpfApplication1
    {
        internal class MyModel : INotifyPropertyChanged
        {
            private int _number;
            private string _value;
    
            public int Number
            {
                get { return _number; }
                set
                {
                    if (value == _number) return;
                    _number = value;
                    OnPropertyChanged();
                }
            }
    
            public string Value
            {
                get { return _value; }
                set
                {
                    if (value == _value) return;
                    _value = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
