    static void Main(string[] args)
    {
        ServiceForm sf = new ServiceForm();
        sf.ServiceFormFields = new List<ServiceFormField> 
        { 
            new ServiceFormField { ChildrenTables = new List<string> { "a", "b", "c"}},
            new ServiceFormField { ChildrenTables = new List<string> { "tra la la", "xxx"}},
            new ServiceFormField { ChildrenTables = new List<string> { "TTTTT" }},
            new ServiceFormField { ChildrenTables = new List<string> { "123455", "8157125", "1763123"}},
            new ServiceFormField { ChildrenTables = new List<string> { " ", " ", " ", "   "}}
        };
        var ordered= sf.ServiceFormFields.OrderByDescending(f => string.Join(",", f.ChildrenTables)).ToList();
        foreach(ServiceFormField sff in ordered)
        {
            foreach(string s in sff.ChildrenTables)
            {
                Console.WriteLine(s);
            }
        }
    }
