    public class Employee
    {
        // ...
    
        public int basicSalary {get; private set;};
        public int hraSalary {get; private set;};
    
        public void CalculateSalary(int salary)
        {      
            this.basicSalary = salary * (0.40);
            this.hraSalary = this.basicSalary * (0.50); 
        }
    
        // ...
    }
