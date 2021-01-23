     <system.serviceModel>
    <services>
      <service name="App.Services.Managers.HelloWorldManager" behaviorConfiguration="DefaultServiceBehavior">
        <host>
          <baseAddresses>
            <add baseAddress="http://localhost:8087/MyService"/>
          </baseAddresses>
        </host>
        <endpoint address="HelloWorldService" binding="wsHttpBinding" contract="App.Services.Contracts.IHelloWorldService"></endpoint>
      </service>
    </services>
    <behaviors>
      <serviceBehaviors>
        <behavior name="DefaultServiceBehavior">
          <serviceMetadata httpGetEnabled="True" httpsGetEnabled="true"/>
          <serviceDebug includeExceptionDetailInFaults="False" />
        </behavior>
      </serviceBehaviors>
    </behaviors>
