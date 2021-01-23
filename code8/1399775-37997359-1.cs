    using (var ctx = new DataContextClass())
    {
        var idParam = new SqlParameter
        {
            ParameterName = "id",
            Value = 1
        };
        var table1List = ctx.Database.SqlQuery<table1>("exec searchProgramUnitResult @id ", idParam).ToList<Course>();
        foreach (table cs in table1List)
            Console.WriteLine("Name: {0}", cs.Name);
    }
