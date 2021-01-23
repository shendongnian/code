			<basicHttpBinding>
                <binding name="BasicHttpBinding_ITestService"
				    <!-- your binding settings -->
                </binding>
            </basicHttpBinding>
			
			<behaviors>
              <serviceBehaviors>
                <behavior name="testBehavior">
                  <serviceMetadata httpGetEnabled="true" />
                  <serviceDebug includeExceptionDetailInFaults="true" />
                </behavior>
              </serviceBehaviors>
            </behaviors>
			
			<services>
				<service behaviorConfiguration="testBehavior"  name="TestServiceReference.TestService">
					<endpoint
					          address=""
							  binding="basicHttpBinding"
							  bindingConfiguration="BasicHttpBinding_ITestService"
							  contract="TestServiceReference.ITestService" 
							  name="BasicHttpBinding_ITestService" />
				</service>
            </services>
