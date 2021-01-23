    using (SqlConnection scn = new SqlConnection("Data Source = 'PAULO'; Initial Catalog=ShoppingCartDB;Integrated Security =True"))
    {
        scn.Open();
        SqlCommand cmd = new SqlCommand("SELECT CreditRequest FROM CreditRequests WHERE Username=@Username", scn);
        // Add the parameter required by the query....
        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = variableWithYouUserNameValue;
        // Run the query and get the single row/column returned
        object value = cmd.ExecuteScalar();
        // If it is not null (possible if the where fails) then put on textbox
        if(value != null)
            txtBoxCredit.Text = value.ToString();
    }
