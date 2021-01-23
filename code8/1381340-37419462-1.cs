    for (int j = 0; j < items.Count; j++)
    {
         cmd = new SqlCommand();
         cmd.CommandText = "INSERT BeaconInfo (ID, Name, RSSI) VALUES (171, @item, 276)";
         //ID is int type, Name is varchar type, RSSI is int type
         cmd.Connection = sqlConnection1;
    
         sqlConnection1.Open();
         cmd.Parameters.Add(New SqlParameter("@item", items[j]));
         cmd.ExecuteNonQuery();
         sqlConnection1.Close();
    }
