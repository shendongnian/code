    decimal GetTotalMaterialCost()
    {
        decimal total = 0;
        using(SqlConnection con = new SqlConnection(....constringhere...)
        using(SqlCommand cmd = new SqlCommand(querytext, con))
        {
            con.Open();
            .....
         }
        return total;
    }
