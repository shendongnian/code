    string projectName = "EXCO";
    string location = "ANYWHERE";
    string countryCode = "XX";
    using (var ctx = new RAContext())
    using (var cmd = ctx.Database.Connection.CreateCommand())
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "RA.RA_REGISTERASSET";
        var projectNameParam = new OracleParameter("inProjectName", OracleDbType.Varchar2, projectName, ParameterDirection.Input);
        var countryCodeParam = new OracleParameter("inCountryCode", OracleDbType.Varchar2, countryCode, ParameterDirection.Input);
        var locationParam = new OracleParameter("inLocation", OracleDbType.Varchar2, location, ParameterDirection.Input);
        var assetRegisteredParam = new OracleParameter("OutAssetRegistered", OracleDbType.Varchar2, ParameterDirection.Output);
        cmd.Parameters.AddRange(new[] { projectNameParam, countryCodeParam, locationParam, assetRegisteredParam });
        cmd.Connection.Open();
        var result = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        assetRegistered = (string)assetRegisteredParam.Value;
    }
