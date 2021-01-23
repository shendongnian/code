    try
    {
        string insert  = "INSERT INTO Companii (Name,Address,City,RegNo) 
                          VALUES(@name,@address,@city,@regno);
                          SELECT SCOPE_IDENTITY()";
        using (SqlConnection con = new SqlConnection(cs))
        using (SqlCommand cmd = new SqlCommand(insert, con))
        {
            con.Open();
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtBoxCity.Text;
            .... and on for the other parameters ....
            int companyID = Convert.ToInt32(cmd.ExecuteScalar());
            ... work with the just added company if required
        }
    }
    catch (Exception er) 
    { MessageBox.Show(er.Message); }
