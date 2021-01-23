    using System.Web.Configuration;
    var trustsection = ((System.Web.Configuration.TrustSection)
                       WebConfigurationManager.GetSection("system.web/trust"));
    bool isLegacyCasModel = trustsection.LegacyCasModel;
    string level = trustsection.Level; 
