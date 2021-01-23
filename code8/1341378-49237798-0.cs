    var version = Microsoft.Data.Edm.Csdl.CsdlConstants.EdmxVersion2;
    var builder = new ODataConventionModelBuilder
    {
       // OData V2.0
       DataServiceVersion = version,
       MaxDataServiceVersion = version
    };
    // Generate Model
    var edmModel = builder.GetEdmModel();
    // CSDL Version 2.0
    edmModel.SetEdmVersion(version);
    // Set Edmx Version
    edmModel.SetEdmxVersion(version);
