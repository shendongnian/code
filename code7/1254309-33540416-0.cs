    <system.diagnostics>
    <sources>
      <source name="System.ServiceModel">
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
    <switches>
      <add name="System.ServiceModel" value="Critical, Error"/>
    </switches>
    <sharedListeners>
      <add initializeData="Diagnostics.svclog" type="System.Diagnostics.XmlWriterTraceListener" name="xml">
        <filter type="System.Diagnostics.EventTypeFilter" initializeData="Critical, Error"/>
      </add>
    </sharedListeners>
    <trace autoflush="true" />
