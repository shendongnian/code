    SqlCommand Cmd = Connection.CreateCommand();
    Cmd.CommandType = CommandType.StoredProcedure;
    Cmd.CommandText = "ConsoleClosingIDSearch";
    Cmd.Parameters.Add("@StartConsoleClosingID", SqlDbType.Int).value = Convert.ToInt32(TextBox1.Text);
    Cmd.Parameters.Add("@EndConsoleClosingID ", SqlDbType.Int).value = Convert.ToInt32(TextBox2.Text);
    
    SqlDataAdapter Da = New SqlDataAdapter(Cmd);
    DataTable dt = New DataTable();
    Da.Fill(dt);
    
    GridView1.DataSource = dt;
    GridView1.DataBind();
