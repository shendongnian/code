    public class employee
    {
        public int ID {get;set;}
        public String Name {get;set;}
        public int Salary {get;set;}
    }
    public class employeeManager : employee
    {
       public void ExceptInputOutput()
       { 
           //ID,Name,Salary are accessible
       }
    }
