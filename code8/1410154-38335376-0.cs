    public class Student : INotifyPropertyChanged
        {
            public ObservableCollection<int> Grades { get; set; }
            private string _Name;
            public string Name {
                get {
                    return _Name;
                }
                set {
                    _Name = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                }
            }
            private int _Grade;
            public int Grade {
                get {
                    return _Grade;
                }
                set {
                    _Grade = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Grade"));
                    OnPropertyChanged(new PropertyChangedEventArgs("GoodStudent"));
                }
            }
            private bool _GoodStudent;
            public bool GoodStudent {
                get { return this.Grade >= 90; }
            }
            public Student(string name, int g)
            {
                Grades = new ObservableCollection<int> { 30, 40, 90, 100 };
                this.Name = name;
                this.Grade = g;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, e);
                }
            }
        }
