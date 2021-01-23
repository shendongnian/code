    using(var context = new EmployeeContext)
    {
        context.Connection.Open();
        // and then here I am accessing some database objects
        // and then calling context.SaveChanes();
    }
