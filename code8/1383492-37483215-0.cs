    da.Fill(ds, "client");
    DataTable client = ds.Tables["client"];
    DataRow newClientRow = client.NewRow();
    ... ... ... 
    client.Rows.Add(newClientRow);
    da.Update(client);
