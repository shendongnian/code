    var qry = new SqlSelect
    (
        new SqlSelect<Person>()
            .AddFields(p => p.Id, p => p.Name)
            .Where(SqlFilter<Person>.From(p => p.Name).EqualTo("Sergey"))
        , new SqlAlias("inner")
    ).AddFields<Person>(p => p.Name);
    
    Console.WriteLine(qry.ParametricSql);
    Console.WriteLine("---");
    Console.WriteLine(string.Join("; ", qry.Parameters
        .Select(p => $"Name = {p.ParameterName}, Value = {p.Value}")));
