    <configSections>
        <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
          <section name="[myDllname].Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false"/>
        </sectionGroup>
      </configSections>
      <system.web>
        <globalization uiCulture="auto" culture="auto"/>
        <customErrors mode="Off"/>
        <pages validateRequest="false" controlRenderingCompatibilityVersion="3.5" clientIDMode="AutoID">
          <controls>
            <add tagPrefix="csla" namespace="Csla.Web" assembly="Csla, Version=3.0.3.0, Culture=neutral, PublicKeyToken=93be5fdc093e4c30"/>
          </controls>
        </pages>
        <!--
              Set compilation debug="true" to insert debugging
              symbols into the compiled page. Because this
              affects performance, set this value to true only
              during development.
        -->
        <compilation debug="true" targetFramework="4.5.1">
          <assemblies>
            <add assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
          </assemblies>
        </compilation>
        <identity impersonate="true"/>
        <authentication mode="Windows"/>
      </system.web>
