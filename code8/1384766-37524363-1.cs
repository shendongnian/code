       while (reader.Read())
        {  
           if (reader.Name == "Name")
            {
                listbox1.Items.Add(reader.Value);
                dr = dt.NewRow();
                dr["Name"] = value;
                dt.Rows.Add(dr);
            }
        
            if (reader.Name == "Date")
            {
                listbox2.Items.Add(reader.Value);
                dr = dt.NewRow();
                dr["Date"] = value;
                dt.Rows.Add(dr);
            }      
        }
