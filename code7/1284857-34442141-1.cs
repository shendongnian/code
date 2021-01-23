    public class Employee : INotifyPropertyChanged
    {
        private int _employeeID;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID
        {
            get { return _employeeID; }
            set
            {
             //Code comited  
            }
        }
