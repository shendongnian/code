    static void Main(string[] args)
    {
        List<Employee> employee = new List<Employee>();
        employee.Add(new Employee("Sudhakaran"));
        employee.Add(new Employee("Unnikrishnan"));
        employee.Add(new Employee("Meenakumari"));
        employee.Add(new Employee("Vijaya Lekshmi Menon"));
        employee.Add(new Employee("Seetha Devi Amma"));
        employee.Add(new Employee("Reghunathan Pillai"));
        employee.Add(new Employee("Parameswaran"));
        employee.Add(new Employee("Vani Parameswaran"));
        employee.Add(new Employee("Man Mohan"));
        employee.Add(new Employee("Anil Kumar"));
        employee.Add(new Employee("Athira"));
        foreach (Employee emp in employee) //Not working.
        {
            emp.Display();
        }
        Console.ReadLine();
    }
    public class Employee
    {
        public string name { get; set; }
        public Employee(string name)
        {
            this.name = name;
        }
        public void Display()
        {
            Console.WriteLine(name);
            
        }
    }
