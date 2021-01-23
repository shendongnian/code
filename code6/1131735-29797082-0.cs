    class UProgram
    {
       //private member variables for UProgram
        private string programName;
        private string departmentName; 
        private Degree __degree;
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
    public Degree UProgDegree
    {
        get{return __degree;}
        set {__degree = value;}
    }
}
