    public class ViewModel: INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
      public Employee SelectedEmployee
      {
        get { return selectedEmployee; }
        set
        {
            if (selectedEmployee != value)
            {
                selectedEmployee = value;
                EmployeesView.Refresh();
                OnPropertyChanged();
            }
        }
    }
