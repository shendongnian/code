    //Generated code
    this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
    //Button click handler
    public void btnFind_Click(object sender, EventArgs e)
    {
      var resultset = GetData();
      
      //Do whatever with data here
      //...
    }
    //Query database
    public DataTable GetData()
    {
      UtilitiesClass ru = new UtilitiesClass();
      string connectionString = ru.getConnectionString();
      DataTable dt = new DataTable();
      SqlConnection myConnection = new SqlConnection(connectionString);
      try
      {
        myConnection.Open();
        SqlCommand cmd = new SqlCommand("FindCust", myConnection);
        cmd.Parameters.AddWithValue("@cust", txtCust.Text.Trim());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter ta = new SqlDataAdapter(cmd);
        ta.Fill(dt);
        myConnection.Close();
      }
      catch (Exception x)
      {
        MessageBox.Show(e.ToString());
      }
      return (dt);  
    }
