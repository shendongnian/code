    <?xml version="1.0"?>
    <configuration>
    	<system.web>
    		<compilation debug="true" targetFramework="4.0"/>
    	</system.web>
      <system.webServer>
        <modules runAllManagedModulesForAllRequests="true"/>
      </system.webServer>
      <system.serviceModel>
    
        <serviceHostingEnvironment>
          <baseAddressPrefixFilters>
              <add prefix="http://localhost:1726/WcfSessionMgt/"/>
          </baseAddressPrefixFilters>
        </serviceHostingEnvironment>
        <behaviors>
          <serviceBehaviors>
            <behavior name="ServiceBehavior">
              <serviceMetadata httpGetEnabled="true"/>
              <serviceDebug includeExceptionDetailInFaults="false"/>
            </behavior>
          </serviceBehaviors>
          <endpointBehaviors>
            <behavior name="JsonBehavior">
              <webHttp/>
            </behavior>
          </endpointBehaviors>
        </behaviors>
        <services>
          <service behaviorConfiguration="ServiceBehavior" name="Service">
             <endpoint address="http://localhost:1726/WcfSessionMgt/Service.svc" binding="webHttpBinding" contract="IService" behaviorConfiguration="JsonBehavior">
              <identity>
                <dns value="http://localhost:1726"/>
              </identity>
            </endpoint>
            <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange"/>
          </service>
        </services>
      </system.serviceModel>
      <system.diagnostics>
        <sources>
          <source name="System.ServiceModel"
                  switchValue="Information, ActivityTracing"
                  propagateActivity="true">
            <listeners>
              <add name="traceListener"
                  type="System.Diagnostics.XmlWriterTraceListener"
                  initializeData= "c:\log\Traces.svclog" />
            </listeners>
          </source>
        </sources>
      </system.diagnostics>
    </configuration>
