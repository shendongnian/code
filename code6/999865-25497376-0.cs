    using (var db = new Context())
    {
        db.Database.Connection.Open();
        var cmd = db.Database.Connection.CreateCommand();
        cmd.CommandText = "SP @Param1, @Param2";
        cmd.Parameters.Add(new SqlParameter("Param1", ped));
        cmd.Parameters.Add(new SqlParameter("Param2", 25));
        List<List<object>> items = new List<List<object>>();
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var item = new List<Object>();
            items.Add(item);
            for (int i = 0; i < reader.FieldCount ; i++)
                item.Add(reader[i]);
        }
        return Request.CreateResponse<List<object>>(HttpStatusCode.OK, items);
    }
