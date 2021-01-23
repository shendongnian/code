    public class EmployeesEditViewModel : INotifyPropertyChanged
    {
        public string UserInputNewName
        {
            get
            {
                return Model.EmployeName;
            }
            set
            {
                if (ValidateValue(value))
                {
                    Model.EmployeName = value;
                    ValidationResult = string.Empty;
                    OnPropertyChanged("UserInputNewName");
                }
                else
                {
                    ValidationResult = "Error, name must not be empty.";
                }
            }
        }
        private bool ValidateValue(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
        private string _ValidationResult;
        public string ValidationResult
        {
            get
            {
                return _ValidationResult ?? string.Empty;
            }
            set
            {
                _ValidationResult = value;
                OnPropertyChanged("ValidationResult");
            }
        }
        private EmployeeModel Model { get; set; }
    }
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeName { get; set; }
    }
