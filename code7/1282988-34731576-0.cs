    <!-- WORKAROUND START for NuGet Console error: 
      "The type initializer for 'System.Management.Automation.Runspaces.InitialSessionState' threw an exception" 
      Author: pete1208 from https://github.com/NuGet/Home/issues/1638 -->
    <dependentAssembly>
            <assemblyIdentity name="System.Management.Automation" publicKeyToken="31bf3856ad364e35" />
            <publisherPolicy apply="no" />
          </dependentAssembly>
        <dependentAssembly>
          <assemblyIdentity name="Microsoft.PowerShell.Commands.Utility" publicKeyToken="31bf3856ad364e35" />
          <publisherPolicy apply="no" />
        </dependentAssembly>
        <dependentAssembly>
          <assemblyIdentity name="Microsoft.PowerShell.ConsoleHost" publicKeyToken="31bf3856ad364e35" />
          <publisherPolicy apply="no" />
        </dependentAssembly>
        <dependentAssembly>
          <assemblyIdentity name="Microsoft.PowerShell.Commands.Management" publicKeyToken="31bf3856ad364e35" />
          <publisherPolicy apply="no" />
        </dependentAssembly>
        <dependentAssembly>
          <assemblyIdentity name="Microsoft.PowerShell.Security" publicKeyToken="31bf3856ad364e35" />
          <publisherPolicy apply="no" />
        </dependentAssembly>
        <dependentAssembly>
          <assemblyIdentity name="Microsoft.PowerShell.Commands.Diagnostics" publicKeyToken="31bf3856ad364e35" />
          <publisherPolicy apply="no" />
        </dependentAssembly>
    <!-- WORKAROUND END -->
