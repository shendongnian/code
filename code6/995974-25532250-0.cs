    <system.diagnostics>
    <sources>
      <source propagateActivity="true" name="System.ServiceModel" switchValue="All">
        <listeners>
          <add type="System.Diagnostics.DefaultTraceListener" name="Default">
            <filter type="" />
          </add>
          <add name="xml">
            <filter type="" />
          </add>
        </listeners>
      </source>
      <source name="System.ServiceModel.MessageLogging">
        <listeners>
          <add type="System.Diagnostics.DefaultTraceListener" name="Default">
            <filter type="" />
          </add>
          <add name="xml" />
        </listeners>
      </source>
      
      <source name="CardSpace">
        <listeners>
          <add type="System.Diagnostics.DefaultTraceListener" name="Default">
            <filter type="" />
          </add>
          <add name="xml">
            <filter type="" />
          </add>
        </listeners>
      </source>
      <source name="System.IO.Log">
        <listeners>
          <add type="System.Diagnostics.DefaultTraceListener" name="Default">
            <filter type="" />
          </add>
          <add name="xml">
            <filter type="" />
          </add>
        </listeners>
      </source>
      <source name="System.Runtime.Serialization">
        <listeners>
          <add type="System.Diagnostics.DefaultTraceListener" name="Default">
            <filter type="" />
          </add>
          <add name="xml">
            <filter type="" />
          </add>
        </listeners>
      </source>
      <source name="System.IdentityModel">
        <listeners>
          <add type="System.Diagnostics.DefaultTraceListener" name="Default">
            <filter type="" />
          </add>
          <add name="xml">
            <filter type="" />
          </add>
        </listeners>
      </source>
    </sources>
    <sharedListeners>
      <add initializeData="Traces.svclog" type="System.Diagnostics.XmlWriterTraceListener"
        name="xml" traceOutputOptions="ProcessId, ThreadId">
        <filter type="" />
      </add>
    </sharedListeners>
    </system.diagnostics>
