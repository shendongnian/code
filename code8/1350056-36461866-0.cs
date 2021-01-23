    public string GetNotifications(string[] texts)
    {
        // Create a single string with all values from the texts array.
        // Ex: 'value1','value2','value3'
        // There are many ways to do this; here's one way using string.Join and LINQ:
        var textsAsSingleString = string.Join(",", texts
            .Select(x => "'" + x.Replace("'", "''") + "'")
            .ToArray());
        // Create your query with a WHERE clause that checks against your list
        var query = "SELECT Text, Date " + 
                    "FROM Notifications " + 
                    "WHERE Text NOT IN (" + textsAsSingleString + ")";
        // Execute the query
        SqlCommand cmd = new SqlCommand(query, con);
        ...
    }
