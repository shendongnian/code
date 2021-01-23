    DataTable dt = new DataTable("MyTable");
    dt.Columns.Add(new DataColumn("Name", typeof(string)));
    dt.Columns.Add(new DataColumn("Date", typeof(DateTime))); 
    while (reader.Read())
    {
       dr = dt.NewRow();
       //if (reader.Name == "Name")
       //{
    		// reader.Read();  <-- this isn't needed, you're already reading...
    		listbox1.Items.Add(reader[0].ToString());
            dr["Name"] = reader[0].ToString();
       //}
       //if (reader.Name == "Date")
       //{
    		listbox2.Items.Add(reader[1].ToString());
            dr["Date"] = reader[1].ToString();
       //}
        dt.Rows.Add(dr);
    }
    data.DataSource = dt; 
