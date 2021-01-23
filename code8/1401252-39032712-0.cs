	<configuration>
	  <configSections>
		<sectionGroup name="spring">
		  <!-- other configuration section handler defined here -->
		  <section name="typeAliases" type="Spring.Context.Support.TypeAliasesSectionHandler, Spring.Core"/> 
		 </sectionGroup>
	  </configSections>
	  <spring>
		<typeAliases>
		   <alias name="WebServiceExporter" type="Spring.Web.Services.WebServiceExporter, Spring.Web"/>
		</typeAliases>
	  </spring>
	</configuration>
