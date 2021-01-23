    var query = dt1.AsEnumerable()
        .Where(v => v.Field<string>("col1").Equals("abcd"))
        .Join(dt2.AsEnumerable(), v => v.Field<int>("ID"), c => c.Field<int>("ID"), (v, c) => new { v, c })
        .Where(
            @t => (@t.c.Field<string>("col1").Equals("8776") || @t.c.Field<string>("col1").Equals("8775")))
        .Select(@t => new
        {
            ok = (dt1.AsEnumerable().Where(a => a.Field<string>("stah").Equals("1"))).Count(),
            ok1 = (dt1.AsEnumerable().Where(a => a.Field<string>("stah").Equals("2"))).Count(),
            ok2 = (dt1.AsEnumerable().Where(a => a.Field<string>("stah").Equals("3"))).Count()
        });
