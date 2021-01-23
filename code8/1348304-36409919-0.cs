    // Split the text values into an array of strings
    string[] checkAgeArray = "23,26,27".Split(',');
    DataTable person;
    
    foreach (var row in person.Rows)
    {
        // Compare the string ages to the string value of the integer age in table
    	if (checkAgeArray.Contains(row["age"].ToString()))
    		row["age"] = System.DBNull;
    }
