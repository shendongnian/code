      while (reader.Read())
            {
                if (reader.Name == "name")
                {
                    reader.Read();
                    listBox1.Items.Add(reader.Value);               
                }    
            }
     DataTable dt = new DataTable("MyTable");
     dt.Columns.Add(new DataColumn("Name", typeof(string)));
     foreach (string value in listbox1.Items)
     {
        dr = dt.NewRow();
        dr[0] = value;               
        dt.Rows.Add(dr);
      }
      data.DataSource=dt;
