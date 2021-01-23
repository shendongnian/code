    string projectName = "EXCO";
    string location = "ANYWHERE";
    string countryCode = "XX";
    using (var ctx = new RAContext())
    {
        var projectNameParam = new OracleParameter("inProjectName", OracleDbType.Varchar2, projectName, ParameterDirection.Input);
        var countryCodeParam = new OracleParameter("inCountryCode", OracleDbType.Varchar2, countryCode, ParameterDirection.Input);
        var locationParam = new OracleParameter("inLocation", OracleDbType.Varchar2, location, ParameterDirection.Input);
        var assetRegisteredParam = new OracleParameter("OutAssetRegistered", OracleDbType.Varchar2, ParameterDirection.Output);
        var sql = "BEGIN RA.RA_RegisterAsset(:inProjectName, :inCountryCode, :inLocation, :OutAssetRegistered); END;";
        var result = ctx.Database.ExecuteSqlCommand(sql, projectNameParam, countryCodeParam, locationParam, assetRegisteredParam);
        assetRegistered = (string)assetRegisteredParam.Value;
    }
