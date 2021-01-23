    List<Customer> customers = new List<Customer>();
    foreach(string line in File.ReadLines(filename)
    {
        Customer c = new Customer();
        c.Name = line.Substring(0, 10).Trim();
        c.Address = line.Substring(10, 15).Trim();
        ... and so on for all the other fields....
        customers.Add(c);        
    }
