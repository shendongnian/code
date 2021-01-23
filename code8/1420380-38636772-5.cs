    public bool GetOverAll(int id, DateTime payrollFrom, DateTime payrollTo, out double? overall)
    {
        overall = null;
        string sql = @"
        ;WITH Data AS(
            SELECT t.*
            FROM table 
            WHERE Id     = @Id 
            AND DateFrom = @From 
            AND DateTo   = @To 
            AND Status   = 'Without'
        )
        SELECT HasRows = CAST(CASE WHEN EXIST( SELECT 1 FROM CTE )
                              THEN 1 ELSE 0 END AS bit),
               OverallTotal = SUM(Total)
        FROM CTE";
        using (var con = new SqlConnection("connectionstring"))
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@From", payrollFrom);
            cmd.Parameters.AddWithValue("@To", payrollTo);
            con.Open();
            using (var rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    bool hasRows = rd.GetBoolean(0);
                    if (!rd.IsDBNull(1))
                        overall = rd.GetDouble(1);
                    return hasRows;
                }
                else
                {
                    throw new Exception("This should never be the case!");
                }
            }
        } 
    }
