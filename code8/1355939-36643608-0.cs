    using (SqlDataReader results = sql_cmd.ExecuteReader(CommandBehavior.CloseConnection))
    {
        while (results.Read())
        {
            string Key = rdr["ItemType"].ToString();
            if (TypesMap.ContainsKey(Key))
                item_type = TypesMap[Key];       
        }
    }
