    SqlConnection sqlConnection1 = new SqlConnection();
    sqlConnection1.ConnectionString = @"Data Source=###; Initial Catalog =USICOAL; Integrated Security=True";
    // SQL Connection Config
    // SQL Command Setups
    SqlCommand cmd1 = new SqlCommand();
    cmd1.Connection = sqlConnection1;
    cmd1.CommandText = "SELECT MAX(ACCT_TRN_ID) FROM ACCOUNT_TRANSACTION WHERE account_no = @v_para";
    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
    adapter1.SelectCommand.Parameters.Add(new SqlParameter("@v_para", SqlDbType.Int));
    adapter1.SelectCommand.Parameters["@v_para"].Value = Convert.ToInt32(cardNumber);
            
    int v_ID_value = Convert.ToInt32(cmd1.ExecuteScalar());
            
    SqlCommand cmd2 = new SqlCommand();
    cmd2.Connection = sqlConnection1;
    cmd2.CommandText = "SELECT NEW_ACCT_STS_CODE, NEW_BALANCE from ACCOUNT_TRANSACTION where ACCT_TRN_ID = @v_IDnumber";
    SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
    adapter2.SelectCommand.Parameters.Add(new SqlParameter("@v_IDnumber", SqlDbType.Int));
    adapter2.SelectCommand.Parameters["@v_IDnumber"].Value = v_ID_value;
    // SQL Command Setups
    sqlConnection1.Open();
    DataTable data = new DataTable();
            
    adapter2.Fill(data);
    SummaryGrid.DataSource = data;
    sqlConnection1.Close();
