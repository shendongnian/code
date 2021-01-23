    public class Person : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public int Age
            {
                get { return age; }
                set
                {
                    age = value;
                    FirePropertyChanged("Age");
                }
            }
    
            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                    FirePropertyChanged("Name");
                }
            }
    
            private void FirePropertyChanged(string v)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
            private int age;
            private string name;
        }
