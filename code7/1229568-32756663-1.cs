    <system.identityModel>
    	<identityConfiguration name="serviceidentity">
    		<audienceUris mode="Never">
    			<add value="https://localhost/FedSecurity/"/>
    		</audienceUris>
    		<issuerNameRegistry type="System.IdentityModel.Tokens.ValidatingIssuerNameRegistry, System.IdentityModel.Tokens.ValidatingIssuerNameRegistry">
    			<authority name="http://<asfs aserver>:9643/adfs/services/trust">
    				<keys >
    					<add thumbprint="8D6BF173ERERERFDFE9CE9CD0FB57FB57A5D68403EA88" name="http://<asfs aserver>:9643/adfs/services/trust" />
    				</keys>
    				<validIssuers>
    					<add name="http://<asfs aserver>:9643/adfs/services/trust" />
    				</validIssuers>
    			</authority>
    		</issuerNameRegistry>
    		<!--certificationValidationMode set to "None" by the the Identity and Access Tool for Visual Studio. For development purposes.-->
    		<certificateValidation certificateValidationMode="None" />
    	</identityConfiguration>
    </system.identityModel>
