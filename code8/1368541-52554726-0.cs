    public class Employee : INotifyPropertyChanged
    {
            private int _id;
            private string _name;
            private double _salary;
            private bool _isSelected;
    
            public int Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }
            public double Salary { get => _salary; set => _salary = value; }
            public bool IsSelected
            {
                get
                {
                    return _isSelected;
                }
                set
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
    }
