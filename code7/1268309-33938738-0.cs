    using (SqlConnection SQLC = new SqlConnection( /* as shown by OP */))
    {
      SQLC.Open();
      foreach (XmlNode xnod in Blist)           
      {
        // I guess you would leave those nodes out entirely
        if (xnod.Attributes["id"] == null) continue;
        XmlNode znod = xnod.SelectSingleNode("buy");
        XmlNode dnod = xnod.SelectSingleNode("sell");
        arr[0] = xnod.Attributes["id"].InnerText;
        arr[1] = znod.SelectSingleNode("max").InnerText;
        arr[2] = dnod.SelectSingleNode("max").InnerText;
        
        SqlCommand SQLLookup = new SqlCommand(string.Format("SELECT typeName FROM invTypes WHERE typeID = {0}", arr[0]), SQLC); // don't forget to set the connection
        arr[0] = SQLLookup.ExecuteScalar() as string;
        itm = new ListViewItem(arr);
        itm.Font = new Font("Tahima", 9);
        listView1_Jita.Items.Add(itm);        
      }
    }
