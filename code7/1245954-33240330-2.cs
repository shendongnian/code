    public class ManagerInfo : EmployeeInfo
    {
        private int _EmpNo;
    
        public override int EmpNo
        {
            get { return _EmpNo; }
            set
            {
                if (value < 100) throw new Exception("EmpNo for manager must be greater than 100");
    
                _EmpNo = value;
            }
        }
    }
 
