    class UProgram
    {
        //private member variables for UProgram
        private string programName;
        private string departmentName;
        private Degree degree;
        //public properties for UProgram
        public string ProgramName
        {
            get { return programName; }
            set { programName = value; }
        }
        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }
        public Degree Degree
        {
            get { return degree; }
            set { degree = value; }
        }
    }
