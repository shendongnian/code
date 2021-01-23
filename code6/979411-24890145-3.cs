    private string _SelectedDepartment;
    public string SelectedDepartment
    {
       get { return _SelectedDepartment; }
       set
       {
          if (value == _SelectedDepartment)
             return;
          _SelectedDepartment = value;
          RaisePropertyChanged("SelectedDepartment");
          OnSelectedDepartmentChanged();
       }
    }
    private void OnSelectedDepartmentChanged()
    {
        if (!SelectedDepartment.Equals("Other"))
           Department = string.Empty;
    }
