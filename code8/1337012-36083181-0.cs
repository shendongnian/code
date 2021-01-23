    	<?xml version="1.0" encoding="utf-8"?>
	<configuration>
	  <configSections>
		<section name="system.identityModel" type="System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
		<section name="system.identityModel.services" type="System.IdentityModel.Services.Configuration.SystemIdentityModelServicesSection, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
	  <appSettings>
		<add key="ida:FederationMetadataLocation" value="https://YOURADFS/FederationMetadata/2007-06/FederationMetadata.xml" />
		<add key="ida:Realm" value="https://YOURURL/" />
		<add key="ida:AudienceUri" value="https://YOURURL/" />
	  </appSettings>
	  <system.web>
		<machineKey validationKey="YOURMACHINEKEY" decryptionKey="YOURDECRYPTIONKEY" validation="SHA1" decryption="AES" />
	  </system.web>
	  <system.webServer>
		<modules>
		  <add name="WSFederationAuthenticationModule" type="System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="managedHandler" />
		  <add name="SessionAuthenticationModule" type="System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="managedHandler" />
		</modules>
	  </system.webServer>
	  <system.identityModel>
		<identityConfiguration>
		  <audienceUris>
			<add value="https://YOURURL/" />
		  </audienceUris>
		  <securityTokenHandlers>
			<add type="System.IdentityModel.Services.Tokens.MachineKeySessionSecurityTokenHandler, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
			<remove type="System.IdentityModel.Tokens.SessionSecurityTokenHandler, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
		  </securityTokenHandlers>
		  <certificateValidation certificateValidationMode="None" />
		  <issuerNameRegistry type="System.IdentityModel.Tokens.ValidatingIssuerNameRegistry, System.IdentityModel.Tokens.ValidatingIssuerNameRegistry">
			<authority name="http://YOURADFS/adfs/services/trust">
			  <keys>
				<add thumbprint="YOURCERTIFICATETHUMB" />
			  </keys>
			  <validIssuers>
				<add name="http://YOURADFS/adfs/services/trust" />
			  </validIssuers>
			</authority>
		  </issuerNameRegistry>
		</identityConfiguration>
	  </system.identityModel>
	  <system.identityModel.services>
		<federationConfiguration>
		  <cookieHandler requireSsl="true" name="YOURCOOKIENAME" />
		  <wsFederation passiveRedirectEnabled="true" issuer="https://YOURADFS/adfs/ls/" realm="https://YOURURL/" requireHttps="true" />
		</federationConfiguration>
	  </system.identityModel.services>
	</configuration>
