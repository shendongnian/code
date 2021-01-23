    while (rdr.Read())
    {
       string mac = rdr.GetString(0);
       ListItem li = new ListItem();
       li.Value = "yourBindedValue";// some value from database column
       li.Text = "yourBindedText";// use mac if its text.
       int index = Checkedlistbox1.Items.IndexOf(li);
       if (index >= 0)
       {
          Checkedlistbox1.SetItemChecked(index, true);
       }
    } 
