    var list=new List<Package>();
    using(SqlDataReader dr = cmdss.ExecuteReader())
    {
       while (dr.Read())
       {
            var p = new Package();
            p.Id=reader.GetInt32(reader.GetOrdinal("Id"));
            p.Name=reader.GetString(reader.GetOrdinal("pkgName"));
            p.Price=reader.GetDecimal(reader.GetOrdinal("Price"));
            list.Add(p);
       }
    }
     
