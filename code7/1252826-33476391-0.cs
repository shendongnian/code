    <system.web>
       <httpRuntime targetFramework="4.5" maxRequestLength="50000000" />
       all other settings remove for Brevity.....
    </system.web>
     <system.webServer>
        <security>
          <requestFiltering>
            <requestLimits maxAllowedContentLength="2147483648" />
           
          </requestFiltering>
        </security>
        all other settings remove for Brevity.....
     </system.webServer>
    <system.web.extensions>
        <scripting>
          <webServices>
            <jsonSerialization maxJsonLength="50000000" recursionLimit="500">
              <converters></converters>
            </jsonSerialization>
          </webServices>
        </scripting>
      </system.web.extensions>
