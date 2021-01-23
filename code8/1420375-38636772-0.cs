    public double? GetOverAll(int Id, DateTime payrollFrom, DateTime payrollTo)
    {
        string sql = @"
        ;WITH Data AS(
            SELECT t.*
            FROM table 
            WHERE Id=@Id 
            AND DateFrom=@From 
            AND DateTo=@To 
            AND Status='Without'
        )
        SELECT HasRows = CAST(CASE WHEN EXIST( SELECT 1 FROM CTE )
                              THEN 1 ELSE 0 END AS bit),
               OverallTotal = SUM(Total)
        FROM CTE";
        using (var con = new SqlConnection("connectionstring"))
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@From", payrollFrom);
            cmd.Parameters.AddWithValue("@To", payrollTo);
            con.Open();
            using (var rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    bool hasRows = rd.GetBoolean(0);
                    double? result = null;
                    if (hasRows) result = rd.GetDouble(1);
                    return result;
                }
                else
                {
                    throw new Exception("This should never be the case!");
                }
            }
        } 
    }
