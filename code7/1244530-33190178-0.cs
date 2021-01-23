    public ObservableCollection<Department> Departments {
            get { return _departments; }
            set {
                _departments = value;
                onPropertyChanged(nameof(Departments));
            }
        }
