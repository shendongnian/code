    <system.serviceModel>
        <services>
          <service behaviorConfiguration="ValidatorServiceBehaviour"
                   name="WCFServiceLibrary.SettingsService">
            <endpoint binding="basicHttpBinding"
                      bindingConfiguration="ValidatorBinding"
                      contract="PDAErsteinService.IPDAErsteinMobileService"  />
            <host>
              <baseAddresses>
                <add baseAddress="http://localhost:8080/PDAErsteinService/" />
              </baseAddresses>
            </host>
          </service>
        </services>
    
        <behaviors>
          <serviceBehaviors>
            <behavior name="ValidatorServiceBehaviour">
              <serviceDebug httpsHelpPageEnabled="true"
                            includeExceptionDetailInFaults="true" />
              <serviceMetadata httpGetEnabled="true" />
              <serviceCredentials>
                <userNameAuthentication userNamePasswordValidationMode="Custom"
                                        customUserNamePasswordValidatorType="UserValidator.Validator, UserValidator" />
              </serviceCredentials>
            </behavior>
          </serviceBehaviors>
        </behaviors>
    
        <bindings>
          <basicHttpBinding>
            <binding name="ValidatorBinding">
              <security mode="TransportCredentialOnly">
                <transport clientCredentialType="Basic"/>
              </security>
            </binding>
    
          </basicHttpBinding>
        </bindings>
    
      </system.serviceModel>
