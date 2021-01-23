        Console.WriteLine("Enter Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Working Days:");
        int days = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Working Hours:");
        int hour = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Job Designation:");
        string job = Console.ReadLine();
            if (job == "manager")
            {
                Console.WriteLine("Salary is:" + (days * hour * 200));
            }
            else if (job == "clerk" )
            {
                Console.WriteLine("Salary is:" + (days * hour * 50));
            }
            else
            {
                Console.WriteLine("No Record");
            }
    
