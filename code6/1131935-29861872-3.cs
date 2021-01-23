    <configuration>
      <system.web>
        <pages>
          <controls>
            <!-- all assemblies & namespaces that contain plugins classes -->
            <add assembly="WebApplication1" namespace="WebApplication1.Code" tagPrefix="plugins" />
            <add assembly="MyOtherPlugins" namespace="MyOtherPlugins.Plugins" tagPrefix="plugins" />
          </controls>
        </pages>
      </system.web>
    </configuration>
