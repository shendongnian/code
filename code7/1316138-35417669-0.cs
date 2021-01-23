    [Fact]
    public void DatabaseModeler_provides_table_modeler()
    {
        var q = new LightmapQuery<AspNetRoles>(new SqliteProvider2());
        var q2 = q.Where(role => role.Name == "Admin");
        var result = q2.ToList();
    }
