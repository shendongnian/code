    try
    {   
        string VNumber = null;      //outside the loop
        while (DR.Read())
        {
            #region Fetching DB data
            DateTime TimeStamp = (DateTime)DR["ExceptionDate"];
            VNumber = (string)DR["VisitNumber"];
            Console.Write("Total Visits = " +VNumber "\n");
            #endregion
            DR.Close();
        }
        cmd = new SqlCommand("UPDATE People SET Visits = '0' WHERE VisitNumber = '" + VNumber + "'", connection);   //The name 'VNumber' does not exist in the current context
        cmd.ExecuteNonQuery();
    }
