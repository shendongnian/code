    <system.diagnostics>
    <sources>
      <source name="System.ServiceModel" switchValue="Information,ActivityTracing"
        propagateActivity="true">
        <listeners>
          <add name="xml" />
        </listeners>
      </source>
      <source name="System.ServiceModel.MessageLogging">
        <listeners>
          <add name="xml" />
        </listeners>
      </source>
    </sources>
    <sharedListeners>
      <add initializeData="c:\\TestKVKService\TestKVKService\bin\Debug\Log\Tracesmore.svclog" type="System.Diagnostics.XmlWriterTraceListener"
        name="xml" />
    </sharedListeners>
    <trace autoflush="true" />
