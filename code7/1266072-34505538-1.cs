    <system.serviceModel>
    <services>
      <service name="GRID.CRM.WebServices.CRMRestWebService.CRMRestWebService" behaviorConfiguration="ServiceBehaviour">
        <endpoint address=""  binding="webHttpBinding" contract="GRID.CRM.WebServices.CRMRestWebService.ICRMRestWebService" behaviorConfiguration="web">
        </endpoint>
      </service>
    </services>
    <bindings />
    <client />
    <behaviors>
      <serviceBehaviors>
        <behavior name="ServiceBehaviour">
          <serviceMetadata httpGetEnabled="true"/>
          <serviceDebug includeExceptionDetailInFaults="true"/>
        </behavior>
      </serviceBehaviors>
      <endpointBehaviors>
        <behavior name="web">
          <webHttp/>
        </behavior>
      </endpointBehaviors>
    </behaviors>
    <serviceHostingEnvironment multipleSiteBindingsEnabled="true" aspNetCompatibilityEnabled="true" />
