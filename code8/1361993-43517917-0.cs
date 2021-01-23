    var p = new DynamicParameters(new { a = 1, b = 2 });
    //p.Add("c", dbType: DbType.Int32, direction: ParameterDirection.Output);
    //conn.Execute(@"set @c = @a + @b", p);
    using (var reader = conn.ExecuteReader(@"set @c = @a + @b; select @c;", p))
    {
        //var results = p.Get<int>("@c");
        if (reader.Read())
        {
            var result = reader.GetInt32(0);
        }
    }
