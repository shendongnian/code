    <system.serviceModel>
      <behaviors>
        <endpointBehaviors>
          <behavior name="webBehavior">
            <webHttp/>
          </behavior>
        </endpointBehaviors>
      </behaviors>
      <serviceHostingEnvironment aspNetCompatibilityEnabled="True">
      </serviceHostingEnvironment>
      <services>
        <service name="RestTest.Service1">
          <endpoint address="" behaviorConfiguration="webBehavior" binding="webHttpBinding" bindingConfiguration="" contract="RestTest.IService1">
          </endpoint>
        </service>
      </services>
    </system.serviceModel>
