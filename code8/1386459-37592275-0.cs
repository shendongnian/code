    <system.diagnostics>
      <sources>
          <source name="System.ServiceModel.MessageLogging">
            <listeners>
                     <add name="messages"
                     type="System.Diagnostics.XmlWriterTraceListener"
                     initializeData="c:\temp\messages.svclog" />
              </listeners>
          </source>
          <source name="System.ServiceModel" switchValue="Information,ActivityTracing"
        propagateActivity="true">
            <listeners>
                  <add name="tracing"
                     type="System.Diagnostics.XmlWriterTraceListener"
                     initializeData="c:\temp\tracing.svclog" />
            </listeners>
          </source>
        </sources>
    </system.diagnostics>
