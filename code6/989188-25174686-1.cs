    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Enter number of employees: ");
            Employee.numberOfEmployees = int.Parse(System.Console.ReadLine());
    
            Employee e1 = new Employee();
            
            e.P = new Person(); //add this line
            
            System.Console.Write("Enter the name of the new employee: ");
            e1.P.Name = System.Console.ReadLine();
    
            System.Console.WriteLine("The employee information:");
            System.Console.WriteLine("Employee number: {0}", e1.Counter);
            System.Console.WriteLine("Employee name: {0}", e1.P.Name);
    
            Console.ReadLine();
        }
    }
