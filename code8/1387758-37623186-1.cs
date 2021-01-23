            public class MyClass : INotifyPropertyChanged
        {
            private bool selectedA;
            public bool SelectedA
            {
                get { return !selectedA; }
                set { selectedA = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("SelectedA")); }
            }
            private bool selectedB;
            public bool SelectedB
            {
                get { return !selectedB; }
                set { selectedB = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("SelectedB")); }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
