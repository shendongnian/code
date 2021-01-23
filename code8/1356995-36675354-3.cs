    string count = "SELECT StudentID FROM Student WHERE IntakeID = 'MYVALUE'"
    SqlCommand cmd = new SqlCommand(count, conn);
    string query = "INSERT INTO Docket (DocketNo, StudentID) VALUES ";
    conn.Open();
    bool first = true;
    using (SqlDataReader rdr = cmd.ExecuteReader())
    {
        while (rdr.Read())
        {
            if (first)
              first= false;
            else 
               query += " ,"
            query += "('" + getUniqueKey() + "','" + rdr.GetString(0) + "')";  
        }
    }
    if (!first)
    {
        cmd.CommandText = query;
        cmd.ExecuteNonQuery();
    }
    conn.Close();
