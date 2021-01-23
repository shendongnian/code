    public void sp_insert(string pro_name, Dictionary<string,string> pro_val)
    {
        cnnction.Open();
        cm.CommandText = pro_name;
        cm.Connection = cnnction;
        cm.CommandType = CommandType.StoredProcedure;
    
        foreach (var item in pro_val)
        {
           cm.Parameters.AddWithValue(item.Key, item.Value);
        }
        cm.ExecuteNonQuery();
        cnnction.Close();
    }
