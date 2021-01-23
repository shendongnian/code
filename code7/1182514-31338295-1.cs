    void GetTotalAmount()
    {
        using(var con = new SqlConnection(conString))
        using(var cmd = con.CreateCommand())
        {
           cmd.CommandText = "...";
           con.Open();
           var sum = cmd.ExecuteScalar();
           txtBudget.Text = sum.ToString();
        }
    }
