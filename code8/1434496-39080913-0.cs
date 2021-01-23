    <system.webServer>
      <modules runAllManagedModulesForAllRequests="true">
        <add name="CORSEnablingModule" type="MyCompany.ServiceLibrary.Cors.CORSEnablingModule, MyCompany.ServiceLibrary" />
      </modules>
    </system.webServer>
