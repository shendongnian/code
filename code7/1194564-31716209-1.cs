    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="enterpriseLibrary.ConfigurationSource" type="Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ConfigurationSourceSection, Microsoft.Practices.EnterpriseLibrary.Common, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
      </configSections>
      <enterpriseLibrary.ConfigurationSource selectedSource="System Configuration Source">
        <sources>
          <add name="System Configuration Source" type="Microsoft.Practices.EnterpriseLibrary.Common.Configuration.SystemConfigurationSource, Microsoft.Practices.EnterpriseLibrary.Common, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
          <add name="File-based Configuration Source" type="Microsoft.Practices.EnterpriseLibrary.Common.Configuration.FileConfigurationSource, Microsoft.Practices.EnterpriseLibrary.Common, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
            filePath="data.config" />
        </sources>
        <redirectSections>
          <add sourceName="File-based Configuration Source" name="dataConfiguration" />
          <add sourceName="File-based Configuration Source" name="connectionStrings" />
        </redirectSections>
      </enterpriseLibrary.ConfigurationSource>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
      </startup>
    </configuration>
