    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    class Sorter : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            string nameAtTop = "Lucy";
            string xName = x.Name;
            if (x.Name.Equals(nameAtTop))
            {
                xName = "_";
            }
            string yName = y.Name;
            if (y.Name.Equals(nameAtTop))
            {
                yName = "_";
            }
            return (xName.CompareTo(yName));
        }
    }
    static void Main(string[] args)
    {
        List<Employee> list = new List<Employee>();
        list.Add(new Employee() { Name = "Steve", Salary = 10000 });
        list.Add(new Employee() { Name = "Janet", Salary = 10000 });
        list.Add(new Employee() { Name = "Andrew", Salary = 10000 });
        list.Add(new Employee() { Name = "Bill", Salary = 500000 });
        list.Add(new Employee() { Name = "Lucy", Salary = 8000 });
        Sorter sorter = new Sorter();
        list.Sort(sorter);
        foreach (var element in list)
        {
            Console.WriteLine(element.Name);
        }
    }
