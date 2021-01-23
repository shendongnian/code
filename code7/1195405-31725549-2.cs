    using System;
    class Employee
    {
       public int ID {get; set;}
       public string Name {get; set;}
       public string Gender {get; set;}
       public string City {get; set;}
    
       public override string ToString() 
       {
        return string.Format("Name: {0} \nGender: {1} \nCity: {2} \nID: {3}", Name, Gender, City, ID);
       }   
    }
    class PermanatEmp : Employee
    {
        public float YearlySalary {get; set;}
            public override string ToString() 
            {
                return base.ToString()+string.Format("\nYearly Salary: {0}"), YearlySalary);
            } 
        }   
    }
    
    class TempEmp : Employee
    {
         public float HourlySalary {get; set;}
         public override string ToString()  
         {
            return base.ToString()+string.Format("\nHourly Sal:{0}", HourlySalary);
         } 
    }
