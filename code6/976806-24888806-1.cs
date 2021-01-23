    <configuration>
        <configSections>
    		<section name="dataConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
    		<sectionGroup name="system.web.extensions" type="System.Web.Configuration.SystemWebExtensionsSectionGroup, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35">
    			<sectionGroup name="scripting" type="System.Web.Configuration.ScriptingSectionGroup, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35">
    				<section name="scriptResourceHandler" type="System.Web.Configuration.ScriptingScriptResourceHandlerSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication" />
    				<sectionGroup name="webServices" type="System.Web.Configuration.ScriptingWebServicesSectionGroup, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35">
    					<section name="jsonSerialization" type="System.Web.Configuration.ScriptingJsonSerializationSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="Everywhere" />
    					<section name="profileService" type="System.Web.Configuration.ScriptingProfileServiceSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication" />
    					<section name="authenticationService" type="System.Web.Configuration.ScriptingAuthenticationServiceSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication" />
    					<section name="roleService" type="System.Web.Configuration.ScriptingRoleServiceSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication" />
    				</sectionGroup>
    			</sectionGroup>
    		</sectionGroup>
        </configSections>
    <dataConfiguration defaultDatabase="Snipped"/>
    <connectionStrings>
       <!-- Snipped -->
    </connectionStrings>
    <appSettings configSource="ConfigFiles\AppSettings.prod.config" />
        <system.web>
            <!-- 
                Set compilation debug="true" to insert debugging 
                symbols into the compiled page. Because this 
                affects performance, set this value to true only 
                during development.
    
                Visual Basic options:
                Set strict="true" to disallow all data type conversions 
                where data loss can occur. 
                Set explicit="true" to force declaration of all variables.
            -->
            <compilation debug="true" explicit="true" strict="false">
                <assemblies>
                    <add assembly="System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
                    <add assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
                    <add assembly="System.Data.DataSetExtensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
                    <add assembly="System.Xml.Linq, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
                </assemblies>
            </compilation>
    		<httpHandlers>
    			<remove verb="*" path="*.asmx" />
    			<add verb="*" path="*.asmx" validate="false" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    			<add verb="*" path="*_AppService.axd" validate="false" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    			<add verb="GET,HEAD" path="ScriptResource.axd" validate="false" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    		</httpHandlers>
    		<httpModules>
    			<add name="ScriptModule" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    		</httpModules>
    
    		<pages renderAllHiddenFieldsAtTopOfForm="true">
    
    
    
              <namespaces>
                <clear />
                <add namespace="System" />
                <add namespace="System.Collections" />
                <add namespace="System.Collections.Generic" />
                <add namespace="System.Collections.Specialized" />
                <add namespace="System.Configuration" />
                <add namespace="System.Text" />
                <add namespace="System.Text.RegularExpressions" />
                <add namespace="System.Linq" />
                <add namespace="System.Xml.Linq" />
                <add namespace="System.Web" />
                <add namespace="System.Web.Caching" />
                <add namespace="System.Web.SessionState" />
                <add namespace="System.Web.Security" />
                <add namespace="System.Web.Profile" />
                <add namespace="System.Web.UI" />
                <add namespace="System.Web.UI.WebControls" />
                <add namespace="System.Web.UI.WebControls.WebParts" />
                <add namespace="System.Web.UI.HtmlControls" />
              </namespaces>
    
              <controls>
                <add tagPrefix="asp" namespace="System.Web.UI" assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
                <add tagPrefix="asp" namespace="System.Web.UI.WebControls" assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    			  <add tagPrefix="Telerik" namespace="Telerik.Web.UI" assembly="Telerik.Web.UI" />
    		  </controls>
    
            </pages>
    	
    		<customErrors mode="RemoteOnly" defaultRedirect="~/Error.aspx" />
    		<!--
                The <authentication> section enables configuration 
                of the security authentication mode used by 
                ASP.NET to identify an incoming user. 
            -->
            <authentication mode="Windows" />
            <machineKey decryptionKey="snipped,IsolateApps" validationKey="snipped,IsolateApps" />
            <!--
                The <customErrors> section enables configuration 
                of what to do if/when an unhandled error occurs 
                during the execution of a request. Specifically, 
                it enables developers to configure html error pages 
                to be displayed in place of a error stack trace.
    
            <customErrors mode="RemoteOnly" defaultRedirect="GenericErrorPage.htm">
                <error statusCode="403" redirect="NoAccess.htm" />
                <error statusCode="404" redirect="FileNotFound.htm" />
            </customErrors>
            -->
    
        </system.web>
    
        <system.codedom>
          <compilers>
            <compiler language="c#;cs;csharp" extension=".cs" warningLevel="4" type="Microsoft.CSharp.CSharpCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
              <providerOption name="CompilerVersion" value="v3.5" />
              <providerOption name="WarnAsError" value="false" />
            </compiler>
            <compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" warningLevel="4" type="Microsoft.VisualBasic.VBCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
              <providerOption name="CompilerVersion" value="v3.5" />
              <providerOption name="OptionInfer" value="true" />
              <providerOption name="WarnAsError" value="false" />
            </compiler>
          </compilers>
        </system.codedom>
    
        <!-- 
            The system.webServer section is required for running ASP.NET AJAX under Internet
            Information Services 7.0.  It is not necessary for previous version of IIS.
        -->
        <system.webServer>
          <validation validateIntegratedModeConfiguration="false" />
          <modules>
                <remove name="ScriptModule-4.0" />
                <remove name="UrlRoutingModule-4.0" />
                <remove name="ServiceModel" />
            <remove name="ScriptModule" />
            <add name="ScriptModule" preCondition="managedHandler" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
                <add name="ErrorHandlerModule" type="System.Web.Mobile.ErrorHandlerModule, System.Web.Mobile, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" preCondition="managedHandler" />
                <add name="ServiceModel" type="System.ServiceModel.Activation.HttpModule, System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="managedHandler" />
          </modules>
          <handlers>
            <remove name="WebServiceHandlerFactory-Integrated" />
            <remove name="ScriptHandlerFactory" />
            <remove name="ScriptHandlerFactoryAppServices" />
            <remove name="ScriptResource" />
                <add name="*.asmx_*" path="*.asmx" verb="*" type="System.Web.Services.Protocols.WebServiceHandlerFactory, System.Web.Services, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" preCondition="integratedMode,runtimeVersionv2.0" />
                <add name="*.rem_*" path="*.rem" verb="*" type="System.Runtime.Remoting.Channels.Http.HttpRemotingHandlerFactory, System.Runtime.Remoting, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="integratedMode,runtimeVersionv2.0" />
                <add name="*.soap_*" path="*.soap" verb="*" type="System.Runtime.Remoting.Channels.Http.HttpRemotingHandlerFactory, System.Runtime.Remoting, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="integratedMode,runtimeVersionv2.0" />
            <add name="ScriptHandlerFactory" verb="*" path="*.asmx" preCondition="integratedMode" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
            <add name="ScriptHandlerFactoryAppServices" verb="*" path="*_AppService.axd" preCondition="integratedMode" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
            <add name="ScriptResource" preCondition="integratedMode" verb="GET,HEAD" path="ScriptResource.axd" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
          </handlers>
            <urlCompression doStaticCompression="false" />
            <staticContent>
                <mimeMap fileExtension=".axd" mimeType="application/javascript" />
            </staticContent>
        </system.webServer>
    
    
        <runtime>
          <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
            <dependentAssembly>
              <assemblyIdentity name="System.Web.Extensions" publicKeyToken="31bf3856ad364e35" />
              <bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="3.5.0.0" />
            </dependentAssembly>
            <dependentAssembly>
              <assemblyIdentity name="System.Web.Extensions.Design" publicKeyToken="31bf3856ad364e35" />
              <bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="3.5.0.0" />
            </dependentAssembly>
          </assemblyBinding>
        </runtime>
    
    
    </configuration>
