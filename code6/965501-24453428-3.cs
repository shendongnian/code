      <system.serviceModel>
    
        <extensions>
          <behaviorExtensions>
            <add name="crossOriginResourceSharingBehavior" type="Nelibur.ServiceModel.Behaviors.EnableCrossOriginResourceSharingBehavior, Nelibur" />
          </behaviorExtensions>
        </extensions>
    ...
        <services>
          <service name="Nelibur.ServiceModel.Services.Default.JsonServicePerCall">
            <host>
              <baseAddresses>
                <add baseAddress="http://127.0.0.1:61111/webhost" />
                <add baseAddress="https://127.0.0.1:61112/webhost" />
              </baseAddresses>
            </host>
            <endpoint binding="webHttpBinding"
                      contract="Nelibur.ServiceModel.Contracts.IJsonService" behaviorConfiguration="jsonBehavior" bindingConfiguration="webHttpBinding"/>
          </service>
        </services>
        <behaviors>
          <endpointBehaviors>
            <behavior name="jsonBehavior">
              <webHttp />
              <crossOriginResourceSharingBehavior />
            </behavior>
          </endpointBehaviors>
        </behaviors>
      </system.serviceModel>
