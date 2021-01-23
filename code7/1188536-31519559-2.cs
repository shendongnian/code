    <configuration>
      <configSections>
        <section name="system.identityModel" type="System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
        <section name="system.identityModel.services" type="System.IdentityModel.Services.Configuration.SystemIdentityModelServicesSection, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
      </configSections>
      <system.webServer>
        <modules>
          <add name="SessionAuthenticationModule" type="System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
          <add name="WSFederatedAuthenticationModule" type="System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
    	</modules>
      </system.webServer>
      <system.identityModel>
        <identityConfiguration saveBootstrapContext="true">
          <issuerNameRegistry type="System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
            <trustedIssuers>
              <!-- Use MMC and the Certificate Snapin to get the thumbprint for your certificate.  It will be different on other machines and this value might not work as is from source control.-->
              <add thumbprint="97f983a05587253b6835d1bd0062000c5d1f398d" name="TokenSigningCert" />
            </trustedIssuers>
          </issuerNameRegistry>
          <audienceUris mode="Never" />
        </identityConfiguration>
      </system.identityModel>
      <system.identityModel.services>
        <federationConfiguration identityConfigurationName="">
          <serviceCertificate>
            <certificateReference x509FindType="FindBySubjectName" findValue="TokenSigningCert" storeLocation="LocalMachine" storeName="TrustedPeople" />
          </serviceCertificate>
          <wsFederation passiveRedirectEnabled="true" issuer="http://login.example.com" realm="http://example.com" requireHttps="false" />
          <cookieHandler requireSsl="false" mode="Default">
            <chunkedCookieHandler chunkSize="2000" />
          </cookieHandler>
        </federationConfiguration>
      </system.identityModel.services>  
    </configuration>
        
