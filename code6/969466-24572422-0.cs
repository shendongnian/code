    <serviceHostingEnvironment aspNetCompatibilityEnabled="false" multipleSiteBindingsEnabled="true" />
    <services>
      <service name="SyncWebServices.Service1" behaviorConfiguration="">
        <endpoint address="" binding="basicHttpBinding" bindingConfiguration="basichttp" contract="SyncWebServices.Service1">
          <identity>
            <dns value="localhost" />
          </identity>
        </endpoint>
        <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
      </service>
    </services>
    <bindings>
      <basicHttpBinding>
        <binding name="basichttp" closeTimeout="00:10:00" openTimeout="00:10:00" receiveTimeout="00:25:00" sendTimeout="00:25:00" maxReceivedMessageSize="4294967296" transferMode="Streamed">
       <readerQuotas maxDepth="4500000" maxStringContentLength="4500000" maxBytesPerRead="40960000" maxNameTableCharCount="250000000" maxArrayLength="4500000" />
          <security mode="None">
          </security>
        </binding>
      </basicHttpBinding>
    </bindings>
    <behaviors>
      <serviceBehaviors>
        <behavior name="">
          <serviceMetadata httpGetEnabled="true" />
          <serviceDebug includeExceptionDetailInFaults="true" httpHelpPageEnabled="true" />
          <serviceThrottling maxConcurrentCalls="500" maxConcurrentSessions="500" />
        </behavior>
      </serviceBehaviors>
    </behaviors>
    <standardEndpoints>
      <webHttpEndpoint>
        <standardEndpoint name="" helpEnabled="true" automaticFormatSelectionEnabled="true" />
      </webHttpEndpoint>
    </standardEndpoints>
