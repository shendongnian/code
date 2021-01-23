    DataSet ds = new DataSet();
    string commandString = "SELECT TOP 0 * FROM client";
    SqlCommand cmd = new SqlCommand(commandString, con);
    con.Open();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    SqlCommandBuilder builder = new SqlCommandBuilder(da);
    da.Fill(ds, "client");
    DataTable client = ds.Tables["client"];
    DataRow newClientRow = client.NewRow();
    ... ... ... 
    client.Rows.Add(newClientRow);
    builder.GetInsertCommand();
    da.Update(client);
