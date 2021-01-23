    using(SqlConnection con = new SqlConnection("Your Connection String Here"))
    { 
        SqlCommand cmd = new SqlCommand("sp_SomeName", con);
        cmd.CommandType = CommandType.StoredProcedure;
         
        //the 2 codes after this comment is where you assign value to the parameters you
        //have on your stored procedure from SQL
        cmd.Parameters.Add("@MONTH", SqlDbType.VarChar).Value = "someValue";
        cmd.Parameters.Add("@YEAR", SqlDbType.VarChar).Value = "SomeYear";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        SqlDataSet ds = new SqlDataSet();
        da.Fill(ds); //this is where you put values you get from the Select command to a 
      //dataset named ds, reason for this is for you to fetch the value from DB to code behind
        foreach(DataRow dr in ds.Tables[0].Rows) // this is where you run through the dataset and get values you want from it.
        {
           someTextBox.Text = dr["Month"].ToString(); //you should probably know this code
        }
    }
