    public class Employee
    {
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set 
            {
                if(string.IsNullOrEmpty(_lastName))
                {
                    _lastName = value;
                }
            }
        }
    }
