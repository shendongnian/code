    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
      </configSections>
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <namespace name="System.Collections.Generic" />
        <namespace name="ConsoleApplication1" />
        <assembly name="ConsoleApplication1" />
        <container>
          <register type="A" mapTo="B" name="B" />
          <register type="A" mapTo="C" name="C" />
          <register type="IList`1[[A]]" mapTo="A[]" />
        </container>
      </unity>
    </configuration>
