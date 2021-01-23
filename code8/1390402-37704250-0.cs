    DateTime finishDate = DateTime.MinValue;
    // This will attempt to parse the value if possible
    DateTime.TryParse(sortedCells[i].finishedDate, out finishDate);
    
    // Build your parameter here
    SqlParameter parameter2 = new SqlParameter("@actualFinish", SqlDbType.DateTime); 
    parameter2.Direction = ParameterDirection.Input;
    // If you are using a nullable field, you may want to explicitly indicate that
    parameter2.IsNullable = true;
    // Then when setting the value, check if you should use the value or null
    if(finishDate == DateTime.MinValue)
    {
         parameter2.Value = DBNull.Value;
    }
    else
    {
         parameter2.Value = finishDate;
    }
    // Finally add your parameter
    command.Parameters.Add(parameter2);
