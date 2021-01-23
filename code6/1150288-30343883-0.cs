    <?xml version="1.0"?>
    
    <configuration>
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false"/>
        <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
          <section name="GlucoseTracker.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        </sectionGroup>
      </configSections>
      <connectionStrings>
        <add name="constr" providerName="System.Data.SqlClient" connectionString="Data Source=localhost;Initial Catalog=Gy;Integrated Security=SSPI;"/>
      </connectionStrings>
      <!--
        For a description of web.config changes for .NET 4.5 see http://go.microsoft.com/fwlink/?LinkId=235367.
    
        The following attributes can be set on the <httpRuntime> tag.
          <system.Web>
            <httpRuntime targetFramework="4.5" />
          </system.Web>
      -->
    <location path="Admin">
      <system.Web>
          <authorization>
            <allow roles="admin"/>
            <deny users="*"/>
          </authorization>
       </system.Web>
    </location>
      <system.web>
        <compilation debug="true" targetFramework="4.5"/>
        <httpRuntime/>
        <pages controlRenderingCompatibilityVersion="4.0">
          <namespaces>
            <add namespace="System.Web.Optimization"/>
          </namespaces>
          <controls>
            <add assembly="Microsoft.AspNet.Web.Optimization.WebForms" namespace="Microsoft.AspNet.Web.Optimization.WebForms" tagPrefix="webopt"/>
          </controls>
        </pages>
        <authentication mode="Forms">
          <forms defaultUrl="~/User/User.aspx" loginUrl="~/Login.aspx" slidingExpiration="true" timeout="2880"></forms>
        </authentication>
    
       
      </system.web>
    </configuration>
