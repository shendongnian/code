        public EmployeeView_HolidaysViewModel()
        {
            _employeeRepository = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IEmployeeRepository>();
            InitializeCollections();
        }
