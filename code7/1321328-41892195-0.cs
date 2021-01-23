    <system.web.webPages.razor>
      <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory" />
      <pages pageBaseType="System.Web.Mvc.WebViewPage">
        <namespaces>
          <add namespace="System.Web.Mvc" />
          <add namespace="System.Web.Mvc.Ajax" />
          <add namespace="System.Web.Mvc.Html" />
          <add namespace="System.Web.Optimization"/>
          <add namespace="System.Web.Routing" />
          <add namespace="PagedList" />        <!--Add this line-->
          <add namespace="PagedList.MVC" />    <!--Add this line-->
        </namespaces>
      </pages>
    </system.web.webPages.razor>
