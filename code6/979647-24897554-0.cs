    var selectStatement = "SELECT Ticket_ID AS [Ticket], Logged_Date AS [Created], Ticket_Type AS [Ticket Type], Department, Priority, Forename, Surname, Ticket_Status AS [Status], Completed_Date AS [Completed], User_Assigned AS [User], Ticket_Subject AS [Subject] FROM Ticket_Data ";
    List<string> whereConditions = new List<string>();
    
    if(!Request.QueryString["Priority"].IsEmpty() ) {
        whereConditions.Add(" Priority = yourPriorityParameterHere ");
        //.....
    }
    
    if(!Request.QueryString["Department"].IsEmpty() ) {
        whereConditions.Add(" Department = yourDepartmentParameterHere ");
        //.....
    }
    var commandText = selectClause + " WHERE "+ string.Join(" AND ", whereConditions) + " ORDER BY LoggedDate DESC";
    //......
    //Fill in parameters, execute sql, live happy
