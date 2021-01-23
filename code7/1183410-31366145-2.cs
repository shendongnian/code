    decimal GetTotalMaterialCost()
    {
        decimal total = 0;
        string query = @"SELECT SUM(rm.Quantity * m.SellingPrice) AS TotalMaterialCost 
                        FROM Resource_Materials rm 
                        JOIN Materials m ON m.MaterialID = rm.MaterialID 
                        JOIN ProjectTasks t ON t.TaskID = rm.TaskID
                        WHERE t.TaskID=@TaskID HAVING COUNT (*) > 0";
        using(SqlConnection con = new SqlConnection(....constringhere...)
        using(SqlCommand cmd = new SqlCommand(query, con))
        {
            con.Open();
            .....
         }
        return total;
    }
