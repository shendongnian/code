    using(SqlConnection con = new SqlConnection(.....))
    using(SqlCommand cmd = new SqlCommand(@"select MAX(Id)
                                            from fianlTable 
                                            WHERE AccountNumber=@num"))
    {
        int maxValue = 0;
        con.Open();
        cmd.Parameters.Add("@num" SqlDbType.NVarChar).Value = textBox4.Text;
        object result = cmd.ExecuteScalar();
        if(result != null) 
          maxValue = Convert.ToInt32(result);
    }
