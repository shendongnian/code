    String sLicenseKey = "Your key from SOLIDWORKS";
    SwDmDocumentOpenError nRetVal = 0;
    SwDmCustomInfoType customInfoType;
    SwDMClassFactory swClassFact = new SwDMClassFactory();
    SwDMApplication swDocMgr = (SwDMApplication)swClassFact.GetApplication(sLicenseKey);
    SwDMDocument17 swDoc = (SwDMDocument17)swDocMgr.GetDocument("C:\Filepath", SwDmDocumentType.swDmDocumentPart, false, out nRetVal);
    SwDMConfigurationMgr swCfgMgr = swDoc.ConfigurationManager;
    SwDMConfiguration14 swCfg = (SwDMConfiguration14)swCfgMgr.GetConfigurationByName("Config Name");
    String materialProperty = swCfg.GetCustomProperty2("Property Name", out customInfoType);
