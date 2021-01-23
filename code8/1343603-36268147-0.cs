               if (_isSelectedEmployeeInActive == value) return;
                _isSelectedEmployeeInActive = value;
                //do updates to collection here
                if (value)
                {
                    SelectedEmployee.EmployeeStatus.Add(new EmployeeStatus("Inactive"));
                }
                else
                {
                    SelectedEmployee.EmployeeStatus.Remove("Inactive"));
                }
                RaisePropertyChanged(() => IsSelectedEmployeeInActive);
            
