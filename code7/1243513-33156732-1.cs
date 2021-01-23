    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
      </configSections>
    
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <alias alias="IMessagingClient" type="ConsoleApplication8.IMessagingClient, ConsoleApplication8" />
        <alias alias="ServiceBusMessagingClient" type="ConsoleApplication8.ServiceBusMessagingClient, ConsoleApplication8" />
        <alias alias="MockMessagingClient" type="ConsoleApplication8.MockMessagingClient, ConsoleApplication8" />
        <alias alias="FailoverMessagingClient" type="ConsoleApplication8.FailoverMessagingClient, ConsoleApplication8" />
        <container>
          <register type="IMessagingClient" name="One" mapTo="ServiceBusMessagingClient" />
          <register type="IMessagingClient" name="Two" mapTo="FailoverMessagingClient">
            <constructor>
              <param name="primaryClient">
                <dependency type="IMessagingClient" name="One" />
              </param>
              <param name="secondaryClient">
                <dependency type="IMessagingClient" name="One" />
              </param>
            </constructor>
          </register>
        </container>
      </unity>
    
    </configuration> 
