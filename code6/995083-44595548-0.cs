    System.Configuration.ConfigurationErrorsException: Root element is missing. (C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\web.config) ---> System.Xml.XmlException: Root element is missing.
       at System.Xml.XmlTextReaderImpl.Throw(Exception e)
       at System.Xml.XmlTextReaderImpl.ParseDocumentContent()
       at System.Configuration.XmlUtil..ctor(Stream stream, String name, Boolean readToFirstElement, ConfigurationSchemaErrors schemaErrors)
       at System.Configuration.BaseConfigurationRecord.InitConfigFromFile()
       --- End of inner exception stack trace ---
       at System.Configuration.ConfigurationSchemaErrors.ThrowIfErrors(Boolean ignoreLocal)
       at System.Configuration.BaseConfigurationRecord.ThrowIfParseErrors(ConfigurationSchemaErrors schemaErrors)
       at System.Configuration.Configuration..ctor(String locationSubPath, Type typeConfigHost, Object[] hostInitConfigurationParams)
       at System.Configuration.Internal.InternalConfigConfigurationFactory.System.Configuration.Internal.IInternalConfigConfigurationFactory.Create(Type typeConfigHost, Object[] hostInitConfigurationParams)
       at System.Web.Configuration.WebConfigurationHost.OpenConfiguration(WebLevel webLevel, ConfigurationFileMap fileMap, VirtualPath path, String site, String locationSubPath, String server, String userName, String password, IntPtr tokenHandle)
       at System.Web.Hosting.HostingEnvironment.get_CacheStoreProviderSettings()
       at System.Web.Caching.Cache.GetObjectCache(Boolean createIfDoesNotExist)
       at System.Web.Caching.Cache.get_Item(String key)
