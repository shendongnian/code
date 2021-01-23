    using (var context = new DbContext())
    {   
        context.Database.ExecuteSqlCommand(
            @"EXEC dbo.MyProc @p1, @p2, @p3, @p4, @p5, @p6, @p7",
            new SqlParameter("p1", int.Parse("0"),
            new SqlParameter("p2", myDate),
            new SqlParameter("p3", DBNull.Value),
            new SqlParameter("p4", DBNull.Value),
            new SqlParameter("p5", myValue),
            new SqlParameter("p6", int.Parse("0")),
            new SqlParameter("p7", DBNull.Value));
    }
