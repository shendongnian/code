    foreach(KeyValuePair<string, Company> kvp in companies)
    {
        foreach (Dictionary<string, Employee> employees in kvp.Value.Employees)
        {
            foreach (KeyValuePair<string, Employee> kvp2 in employees)
            {
                Console.WriteLine(kvp.Value.Name + ", " + kvp2.Value.Name);
            }
        }
    }
