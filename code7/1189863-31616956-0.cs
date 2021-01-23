    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
      </configSections>
    
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <assembly name="MyApp"/>
        <namespace name="MyApp"/>
        <sectionExtension type="Microsoft.Practices.Unity.InterceptionExtension.Configuration.InterceptionConfigurationExtension, Microsoft.Practices.Unity.Interception.Configuration" />
    
        <container>
          <extension type="Interception"/>
          <register type="MyInterceptor">
            <lifetime type="singleton" />
          </register>
          <register type="IRat" mapTo="Rat">
            <interceptor type="InterfaceInterceptor"/>
            <interceptionBehavior type="MyInterceptor"/>
          </register>
        </container>
      </unity>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
      </startup>
    </configuration>
