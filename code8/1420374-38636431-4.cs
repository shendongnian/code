    public decimal? Check(BEL bel)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = dbcon.getcon();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT SUM(Total) as OverallTotal FROM table WHERE Id=@Id " + 
                          "AND DateFrom=@From AND DateTo=@To AND Status='Without'";
        cmd.Parameters.AddWithValue("@Id", bel.CLEmpID);
        cmd.Parameters.AddWithValue("@From", bel.CLPayrollFrom);
        cmd.Parameters.AddWithValue("@To", bel.CLPayrollTo);
    
        object obj = cmd.ExecuteScalar();
        decimal? value = null;
        if (obj != DBNull.Value)
            value = Convert.ToDecimal(obj);
        return value;
    }
    decimal? total = bal.Check(bel);
    if (total.HasValue)
    {
        // do something with the total.Value
    }
    else
    {
    }
