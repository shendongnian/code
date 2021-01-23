    <system.web.webPages.razor>
        <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <pages pageBaseType="YourNameSpace.BasePage"> <!-- Edit This line -->
            <namespaces>
              <add namespace="System.Web.Mvc" />
              <add namespace="System.Web.Mvc.Ajax" />
              <add namespace="System.Web.Mvc.Html" />
              <add namespace="System.Web.Routing" />
              <!-- ommited -->
            </namespaces>
        </pages>
    </system.web.webPages.razor>
