        <system.web.webPages.razor>
            <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
            <pages pageBaseType="System.Web.Mvc.WebViewPage">
              <namespaces>
                <add namespace="LinkApp.Models.Templates"/>
                <add namespace="System.Web.Mvc" />
                <add namespace="System.Web.Mvc.Ajax" />
                <add namespace="System.Web.Mvc.Html" />
                <add namespace="System.Web.Optimization"/>
                <add namespace="System.Web.Routing" />
                <add namespace="LinkApp" />
              </namespaces>
            </pages>
          </system.web.webPages.razor>
    
    Oddly enough, I moved my custom namespace to the bottom, and that fixed it, like this:
    
    <system.web.webPages.razor>
        <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <pages pageBaseType="System.Web.Mvc.WebViewPage">
          <namespaces>
            <add namespace="System.Web.Mvc" />
            <add namespace="System.Web.Mvc.Ajax" />
            <add namespace="System.Web.Mvc.Html" />
            <add namespace="System.Web.Optimization"/>
            <add namespace="System.Web.Routing" />
            <add namespace="LinkApp" />
            <add namespace="LinkApp.Models.Templates"/>
          </namespaces>
        </pages>
      </system.web.webPages.razor>
