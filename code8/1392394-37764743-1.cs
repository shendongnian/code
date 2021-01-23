    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
      </configSections>
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <namespace name="ConsoleApplication1" />
        <container>
          <register type="ConsoleApplication1.A, ConsoleApplication1"
                    mapTo="ConsoleApplication1.B, ConsoleApplication1" name="B" />
          <register type="ConsoleApplication1.A, ConsoleApplication1"
                    mapTo="ConsoleApplication1.C, ConsoleApplication1" name="C" />
        </container>
      </unity>
    </configuration>
