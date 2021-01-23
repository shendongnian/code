    public class Worker
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Bonus { get; set; }
        public Worker(string name, double salary, int bonus)
        {
            this.Name = name;
            this.Salary = salary;
            this.Bonus = bonus;
        }
    }
