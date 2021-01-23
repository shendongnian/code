    var list = new List<string>();
    while(reader.Read())
    {   
        var s = string.Format("{4},{3},{2}, {1}, {0}",
                   reader["ToTime"] == DBNull.Value? "NULL" : reader["ToTime"].ToString(), 
                   reader["FromTime"] == DBNull.Value? "NULL" : reader["FromTime"].ToString(), 
                   reader["Date"].ToString(), 
                   reader["User"].ToString(),
                   reader["Email"].ToString()); 
        Console.WriteLine(s);
        list.add(s);
    }
    
    //create a full string of your list.
    var sb = new StringBuilder();
    foreach(var s in list)
    {
        sb.AppendLine(s);
    }
    
    //set the mail body
    mail.Body = sb.ToString();
