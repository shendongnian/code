    // C# example: Build a document query that return employees that has a salary greater than $40k/year using a dynamic LINQ query filter.
    dynamic storage = new QueryableStorage<DynDocument>("mongodb://user:pass@example.org/MongoDBExample");
    QueryableCollection<DynDocument> employeesCollection = storage.Employees;
    var employeeQuery = employeesCollection
        // Query for salary greater than $40k and born later than early '95.
        .Where("Salary > 40000 and Birthdate >= DateTime(1995,15,3)")
        // Projection and aliasing.
        .Select("new(_id as Email, Birthdate, Name, Timestamp as RegisteredDate)")
        // Order result set by birthdate descending.
        .OrderBy("Birthdate desc")
        // Paging: Skip the first 5 and retrieve only 5.
        .Skip(5).Take(5)
        // Group result set on Birthdate and then on Name.
        .GroupBy("Birthdate", "Name");
    
    // Use a dynamic type so that we can get access to the document's dynamic properties
    foreach (dynamic employee in employeeQuery)
    {
        // Show some information about the employee
        Console.WriteLine("The employee '{0}' was employed {1} and was born in {2}.",
            employee.Email, employee.RegisteredDate, employee.Birthdate.Year);
    }
