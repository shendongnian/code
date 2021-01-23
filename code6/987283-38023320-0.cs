    //using Microsoft.Web.Administration;
    var file = "PATH TO FILE";
    var configFile = new FileInfo(file);
    var virtualDirectoryMapping = new VirtualDirectoryMapping(configFile.DirectoryName, true, configFile.Name);
    var webConfigFileMap = new WebConfigurationFileMap();
    webConfigFileMap.VirtualDirectories.Add("/", virtualDirectoryMapping);
    var webConfig = System.Web.Configuration.WebConfigurationManager.OpenMappedWebConfiguration(webConfigFileMap, "/");
    webConfig.ConnectionStrings.ConnectionStrings.Add(new System.Configuration.ConnectionStringSettings("NAME", "CONNECTION STRING"));
    webConfig.Save();
