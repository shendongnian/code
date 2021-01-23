    protected void Page_Load(object sender, EventArgs e)
    {
      SqlConnection cnn1 = new SqlConnection("Your connection string");
      SqlConnection cnn2 = new SqlConnection("Your connection string");
      SqlCommand cmd1;
      SqlCommand cmd2;
      IAsyncResult result1;
      IAsyncResult result2;
      SqlDataReader reader1;
      SqlDataReader reader2;
  
      try
      {
        cnn1.Open();
  
        cmd1 = new SqlCommand("SP1", cnn1);
        cmd1.CommandType = System.Data.CommandType.StoredProcedure;
        result1 = cmd1.BeginExecuteReader(CommandBehavior.SingleRow);
  
        cnn2.Open();
        cmd2 = new SqlCommand("SP2", cnn2);
        cmd2.CommandType = System.Data.CommandType.StoredProcedure;
        result2 = cmd2.BeginExecuteReader(CommandBehavior.SingleRow);
  
        reader1 = cmd1.EndExecuteReader(result1);
  
        if (reader1.Read())
        {
            Literal1.Text = reader1[0].ToString();
        }
  
        reader1.Close();
  
        reader2 = cmd2.EndExecuteReader(result2);
  
        if (reader2.Read())
        {
            Literal2.Text = reader2[0].ToString();
        }
  
        reader2.Close();
      }
      catch (Exception ex)
      {  
        // raise an exception or do whatever logic you want
      }
      finally
      {
        if (cnn1.State != System.Data.ConnectionState.Closed)
            cnn1.Close();
  
        if (cnn2.State != System.Data.ConnectionState.Closed)
            cnn2.Close();
      }
    }
