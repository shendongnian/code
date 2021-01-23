    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
        <configSections>
            <section name="enterpriseLibrary.ConfigurationSource" type="Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ConfigurationSourceSection, Microsoft.Practices.EnterpriseLibrary.Common, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
        </configSections>
        <enterpriseLibrary.ConfigurationSource selectedSource="File-based Configuration Source">
            <sources>
                <add name="File-based Configuration Source" type="Microsoft.Practices.EnterpriseLibrary.Common.Configuration.FileConfigurationSource, Microsoft.Practices.EnterpriseLibrary.Common, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    filePath="entlib.config" />
            </sources>
        </enterpriseLibrary.ConfigurationSource>
        <startup> 
            <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6"/>
        </startup>
    </configuration>
