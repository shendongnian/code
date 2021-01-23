    foreach(Person p in people)
    {
        Console.WriteLine(p.Name + ", " + p.DateOfBirth.ToString("dd/MMM/yy"));
        if(p is Child)
        {
            Console.WriteLine(p.Name + " has the following toys: " + string.Join(", ", ((Child)p).Toys));
        }
        else if(p is Adult)
        {
            Console.WriteLine(p.Name + " works at " + ((Adult)p).Workplace;
        }
    }
