    <configuration>
      <system.web>
        <compilation strict="false" explicit="true" targetFramework="4.5" />
        <trust level="Full" />
      </system.web>
      <system.webServer>
        <modules runAllManagedModulesForAllRequests="true" />
      </system.webServer>
      <system.serviceModel>
        <extensions>
          <bindingElementExtensions>
            <add name="timestampedTextMsgEncoding" type="WCF.Sample.TimestampedTextMsgEncodingExtension, WCFSample" />
          </bindingElementExtensions>
        </extensions>
        <services>
          <service behaviorConfiguration="WCF.Sample.SampleBehavior" name="WCF.Sample.Service">
            <endpoint address="basic" contract="WCF.Sample.IService" binding="basicHttpBinding" bindingConfiguration="HttpNoAuth" />
            <endpoint address="timestamp" contract="WCF.Sample.IService" binding="customBinding" bindingConfiguration="HttpNoAuthTimestampEncoding" />
          </service>
        </services>
        <bindings>
          <basicHttpBinding>
            <binding name="HttpNoAuth" >
              <security mode="None" >
                <transport clientCredentialType="None" />
              </security>
            </binding>
          </basicHttpBinding>
          <customBinding>
            <binding name="HttpNoAuthTimestampEncoding">
              <timestampedTextMsgEncoding writeEncoding="Utf8TextEncoding" messageVersion="Soap11" />
              <httpTransport authenticationScheme="None" />
            </binding>
          </customBinding>
        </bindings>
        <behaviors>
          <serviceBehaviors>
            <behavior name="WCF.Sample.SampleBehavior">
              <useRequestHeadersForMetadataAddress />
              <serviceMetadata httpGetEnabled="True" />
              <serviceDebug includeExceptionDetailInFaults="False" />
            </behavior>
          </serviceBehaviors>
        </behaviors>
      </system.serviceModel>
    </configuration>
