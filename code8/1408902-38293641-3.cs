    public List<Item> GetAllItems()
    {
        var items = new List<Item>();
        using (var con = new SqlCeConnection(connectionString))
        using (var cmd = new new SqlCeCommand("Select * from tblItem", con))
        {
            conn.Open();
            SqlCeDataReader dr = cmd.ExecuteReader();
            int idOrdinal = dr.GetOrdinal("ID");
            int nameAOrdinal = dr.GetOrdinal("NameA");
            int codeOrdinal = dr.GetOrdinal("Code");
            // other fields ...
            while (dr.Read()) {
                var item = new Item();
                item.ID = dr.GetInt32(idOrdinal);
                item.NameA = dr.GetString(nameAOrdinal);
                item.Code = dr.GetString(codeOrdinal);
               // other fields ...
                items.Add(item);
            }
        }
        return items;
    }
