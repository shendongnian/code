    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Bonus { get; set; }
    
        public Employee(string name, double salary, int bonus)
        {
            this.Name = name;
            this.Bonus = bonus;
            this.Salary = salary;
        }
    }
