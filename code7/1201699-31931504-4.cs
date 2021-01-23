      <configSections>
        <section name="razor" type="Nancy.ViewEngines.Razor.RazorConfigurationSection, Nancy.ViewEngines.Razor" />
        <sectionGroup name="system.web.webPages.razor" type="System.Web.WebPages.Razor.Configuration.RazorWebSectionGroup, System.Web.WebPages.Razor, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35">
          <section name="pages" type="System.Web.WebPages.Razor.Configuration.RazorPagesSection, System.Web.WebPages.Razor, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" />
        </sectionGroup>
      </configSections>
      <razor disableAutoIncludeModelNamespace="false">
        <assemblies>
          <add assembly="System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
          <add assembly="System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
        </assemblies>
      </razor>
