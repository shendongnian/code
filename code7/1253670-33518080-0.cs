    Command.Parameters.Add(":sessionid", MyObj.SessionID);
    
    // Delete all the employees for that session
    
    Command.CommandText = DeleteEmployees;
    
    Command.ExecuteNonQuery();
    
    Command.Parameters.Clear();
    
    // Insert all the current employees in the list object in the db
    
    Command.CommandText = InsertEmployees;
    
    foreach (Company.Employee _emp in MyObj.Employees)
    {
         [[ various parameters]]
        Command.ExecuteNonQuery();
    
        Command.Parameters.Clear();
    }
