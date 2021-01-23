    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration" />
      </configSections>
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <container>
    
          <register type="YourApplication.BusinessObjectClass" mapTo="<ProvidedDll1>.<Namespace>.BusinessObjectClass" />
    
           <!-- For second business class just change the mapping to -->
    
          <register type="YourApplication.BusinessObjectClass" mapTo="<ProvidedDll2>.<Namespace>.BusinessObjectClass" />
    
        </container>
      </unity>
    </configuration>
