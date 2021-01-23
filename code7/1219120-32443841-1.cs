       List<Employee> employee = new List<Employee>();
        do
        {
            Console.WriteLine("Main menu : 1.Add Employee 2.View All employees   3.View by Name");
            option = Convert.ToInt32(Console.ReadLine());
      
    
      switch (option)
        {
            case 1:
                {
                    Employee emp = new Employee();
                    String date;
                    Console.WriteLine("enter the Employee number, name, doj, designation");
                    emp.EmployeeNumber = Convert.ToInt32(Console.ReadLine());
                    emp.Name = Console.ReadLine();
                    date = Console.ReadLine();
                    DateTime doj = new DateTime();
                    if (DateTime.TryParse(date, out doj))
                    {
                        emp.DOJ = doj;
                    }
                    else
                    {
                        Console.WriteLine("please provide the valid date format");
                    }
    
                    emp.Designation = Console.ReadLine();
                    //long Salary = emp.calculateSalary();
                    //Console.WriteLine("Salary : {0}", Salary);
                    employee.Add(emp);
                    break;
                }
            case 2:
                {
                    foreach (var k in employee)
                    {
                        Console.WriteLine("Employee Id: {0}", k.EmployeeNumber);
                        Console.WriteLine("Name: {0}", k.Name);
                        Console.WriteLine("DOJ: {0}", k.DOJ);
                        Console.WriteLine("designation: {0}", k.Designation);
                        //Console.WriteLine("salary: {0}", k.calculateSalary());
                    }
                    break;
                }
            case 3:
                {
                    Console.WriteLine("enter the char");
                    string str = Console.ReadLine();
    
                    foreach (Employee emp in employee)
                    {
                        if (emp.Name.StartsWith(str))
                        {
                            Console.WriteLine(" Name: {0} \n Id:: {1} \n DOJ: {2} \n desig: {3}", emp.Name, emp.EmployeeNumber, emp.DOJ, emp.Designation);
                        }
                    }
                    break;
                }
        }
    } while (option != 4);
