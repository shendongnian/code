    var conn = new SQLiteConnection(sqlitePlatform, "foofoo");
    var query = from customer in conn.Table<Customers>().ToList()
                join call in conn.Table<Calls>().ToList()
                             on customer.ID equals call.CustomerId                
                select new { Customer = customer , Calls = call };
