    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
      </configSections>
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <container>
          <register type="ConsoleApplication1.A, ConsoleApplication1"
                    mapTo="ConsoleApplication1.B, ConsoleApplication1" name="B" />
          <register type="ConsoleApplication1.A, ConsoleApplication1"
                    mapTo="ConsoleApplication1.C, ConsoleApplication1" name="C" />
          <register type="System.Collections.Generic.IList`1[[ConsoleApplication1.A, ConsoleApplication1]], mscorlib"
                    mapTo="ConsoleApplication1.A[], ConsoleApplication1" />
        </container>
      </unity>
    </configuration>
