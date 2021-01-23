    <system.serviceModel>
    <services>
      <service behaviorConfiguration="MyNamespace.CommunicatorServiceBehavior" name="MyNamespace.CommunicatorService">
        <endpoint address="" binding="netNamedPipeBinding" name="netNamedPipeCommunicator" contract="MyNamespace.ICommunicator">
        </endpoint>
        <endpoint address="mex" binding="mexNamedPipeBinding" name="mexNamedPipeCommunicator" contract="IMetadataExchange" />
        <host>
          <baseAddresses>
            <add baseAddress="net.pipe://localhost/CommunicatorService" />
          </baseAddresses>
        </host>
      </service>
    </services>
    <behaviors>
      <serviceBehaviors>
        <behavior name="MyNamespace.CommunicatorServiceBehavior">
          <serviceMetadata httpGetEnabled="false" />
          <serviceDebug includeExceptionDetailInFaults="false" />
        </behavior>
      </serviceBehaviors>
    </behaviors>
