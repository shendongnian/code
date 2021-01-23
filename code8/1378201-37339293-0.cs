    <configuration>
      <appSettings>
        <add key="ChartImageHandler" value="storage=file;timeout=20;dir=c:\TempImageFiles\;" />
      </appSettings>
      <system.webServer>
        <handlers>
          <remove name="ChartImageHandler" />
          <add name="ChartImageHandler" preCondition="integratedMode" verb="GET,HEAD,POST"
            path="ChartImg.axd" type="System.Web.UI.DataVisualization.Charting.ChartHttpHandler, System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
        </handlers>
      </system.webServer>
      <system.web>
        <pages>
          <controls>
            <add tagPrefix="asp" namespace="System.Web.UI.DataVisualization.Charting"
              assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
          </controls>
        </pages>
        <compilation debug="true" targetFramework="4.5">
            <assemblies>
            
            <add assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
          </assemblies>
        </compilation>
        <httpRuntime targetFramework="4.6.1"/>
        <httpHandlers>
          <add path="ChartImg.axd" verb="GET,HEAD,POST" type="System.Web.UI.DataVisualization.Charting.ChartHttpHandler, System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" validate="false"/>
        </httpHandlers>
      </system.web>
    </configuration>
