    private static void LinqToSql()
    {
        DataContext dataContext = new DataContext("data source=.;initial catalog=businessLinqToSql;integrated security=True;MultipleActiveResultSets=True");
        Table<Customer> customers = dataContext.GetTable<Customer>();
        IQueryable<string> query = from c in customers
                                           where c.Name.Length > 5
                                           orderby c.Name.Length
                                           select c.Name.ToUpper();
        foreach (string name in query) Console.WriteLine(name);
    }
