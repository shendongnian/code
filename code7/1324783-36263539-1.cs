    <configuration>
        <system.diagnostics>
          <sources>
            <source name="System.Net" tracemode="includehex" maxdatasize="1024">
              <listeners>
                <add name="ProgressListener"/>
              </listeners>
            </source>
          </sources>
          <switches>
            <add name="System.Net" value="Verbose"/>
          </switches>
          <sharedListeners>
            <add name="ProgressListener"
              type="YourApp.DetailedProgressListener, YourApp" />
          </sharedListeners>
          <trace autoflush="true"/>
        </system.diagnostics>
    </configuration>
