    double totaltime = 0;  // necessary, double is wider than float
    // ...
    
    while (reader.Read())
    {
        double time = reader.GetDouble(0);
        totaltime = totaltime + time;
        // conn.Close(); no, not in this loop, should be closed in the finally or via using-statement
    }
