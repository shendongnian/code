    using System;
    class Employee
    {
       public int ID;
       public string Name;
       public string Gender;
       public string City;
    
       public virtual void Detail() 
       {
        Console.WriteLine("Name: {0} \nGender: {1} \nCity: {2} \nID: {3}", Name, Gender, City, ID);
       }   
    }
    class PermanatEmp : Employee
    {
        public float YearlySalary;
            public override void Detail() {
            Console.WriteLine("Name: {0} \nGender: {1} \nCity: {2} \nID: {3}\nYearly     Sal:{4}", Name, Gender, City, ID, YearlySalary);
        }    
    }
    
    class TempEmp : Employee
    {
         public float HourlySalary;
         public override void Detail() 
         {
            Console.WriteLine("Name: {0} \nGender: {1} \nCity: {2} \nID: {3}\nHourly Sal:{4}", Name, Gender, City, ID, HourlySalary);
         } 
    }
