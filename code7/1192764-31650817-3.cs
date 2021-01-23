	<?xml version="1.0"?>
	<configuration>
	 <appSettings>
		<add key="webPages:Version" value="2.0"/>
	  </appSettings>
		
	  <system.web>
			<customErrors mode="Off"/>
			
		<compilation debug="true" targetFramework="4.0">
		  <assemblies>
			<add assembly="System.Web.Routing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
			<add assembly="System.Web.Mvc, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
		  </assemblies>
		</compilation>
		<pages>
		  <namespaces>
            <add namespace="System.Web.Mvc" />
			<add namespace="System.Web.Routing" />
		  </namespaces>
		</pages>
	  </system.web>
	</configuration>
