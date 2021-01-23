      <system.web>
        <caching>
          <outputCache defaultProvider="AspNetInternalProvider">
            <providers>
              <clear/>
              <add name="CustomProvider" type="YourNamespace.SessionBasedCacheProvider, YourNamespace, Version=1.0.0.0, Culture=neutral"/>
            </providers>
          </outputCache>
        </caching>
    </web>
