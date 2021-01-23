    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    namespace WpfApplication1
    {
        class MainWindowVm : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public MainWindowVm()
            {
                Things = new ObservableCollection<object>();
                Things.Add(new Thing1());
                Things.Add(new Thing2());
            }
    
            public ObservableCollection<Object> Things { get; set; }
    
            private Object _selectedThing;
            public Object SelectedThing
            {
                get
                {
                    return _selectedThing;
                }
                set
                {
                    if (value != _selectedThing)
                    {
                        _selectedThing = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedThing)));
                    }
                }
            }
        }
    }
