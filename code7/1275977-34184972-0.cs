    // sample data
    var table = new DataTable();
    table.Columns.Add("Name", typeof(string));
    table.Columns.Add("Group", typeof(string));
    table.Rows.Add("John", "HR,Finance");
    table.Rows.Add("Tom", "HR,");
    table.Rows.Add("Jonna", "Finance,");
    table.Rows.Add("Adam", "IT,");
    table.Rows.Add("Rachael", "Default,IT,");
    // get a distinct list of all the departments
    var departments = table.AsEnumerable()
                           .SelectMany(r => r.Field<string>("Group").Split(new[] { ',' },
                                            StringSplitOptions.RemoveEmptyEntries))
                           .Distinct();
    // loop through each department
    foreach (string department in departments)
    {
        // get any employees that are apart of the current department
        var employees = table.AsEnumerable()
                             .Where(r => r.Field<string>("Group").Contains(department));
        // write output according to OP's format
        Console.WriteLine("Start - {0}", department);
        foreach (var employee in employees)
            Console.WriteLine(employee.Field<string>("Name"));
        Console.WriteLine("End");
        Console.WriteLine();
    }
