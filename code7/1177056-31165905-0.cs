    using (SqlDataReader dr = createCommand.ExecuteReader())
    {
      int myItemOrdinal = dr.GetOrdinal("MyItem");
      List<object> comboBoxRows = new List<object>();
      while (dr.Read())
      {         
        string myItem = dr.GetString(myItemOrdinal);
        comboBoxRows.Add(myItem);
      }
    }
    comboBox1.BeginInvoke(() => comboBox1.Items.AddRange(comboBoxRows.ToArray()));
