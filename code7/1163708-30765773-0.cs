    if (Date1 >= 0 && Date2 <= 0)
    {
        listView1.Items.Add(dataReader.GetValue(0).ToString());
        listView1.Items[i].SubItems.Add(dataReader.GetValue(1).ToString());// The error appears on this line
    
        listView1.Items[i].SubItems.Add(dt0.ToShortDateString());
        listView1.Items[i].SubItems.Add(dataReader.IsDBNull(3) ? "0" : dataReader.GetString(3));
        listView1.Items[i].SubItems.Add(dataReader.IsDBNull(4) ? "0" : dataReader.GetDouble(4).ToString("n2"));
        listView1.Items[i].SubItems.Add(dataReader.IsDBNull(5) ? "-" : dataReader.GetString(5));
        i++;
    }
 
