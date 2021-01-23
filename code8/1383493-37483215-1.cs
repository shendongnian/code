    SqlCommandBuilder builder = new SqlCommandBuilder(da);
    da.Fill(ds, "client");
    DataTable client = ds.Tables["client"];
    DataRow newClientRow = client.NewRow();
    ... ... ... 
    client.Rows.Add(newClientRow);
    builder.GetInsertCommand();
    da.Update(client);
