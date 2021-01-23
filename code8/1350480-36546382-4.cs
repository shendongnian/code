    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public Employee Model { get; set; }
        private string _empName;
        public string EmpName
        {
            get { return _empName;}
            set
            {
                _empName = value;
                OnPropertyChanged();
            }
        }
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked;}
            set
            {
                _isChecked = value;
                OnPropertyChanged();
            }
        }
        public EmployeeViewModel(Employee model)
        {
            Model = model;
            IsChecked = model.IsChecked;
            EmpName = model.EmpName;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
