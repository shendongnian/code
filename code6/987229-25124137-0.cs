    public static NewCode[] GetAltCode(int altCodeVer, string descrip)
    {
        var sql = @"select Code, Description, VersionID from Code.CodeLookup where versionid=@vers and description=@description";
    
        return ObjectFactory.GetInstance<IDatabaseFactory>().Query<NewCode>(sql, new { vers = altCodeVer, description = descrip, }).ToArray();
    }
