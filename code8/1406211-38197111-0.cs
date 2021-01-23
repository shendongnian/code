    <system.diagnostics>
        <sources>
          <source name="System.ServiceModel.MessageLogging" switchValue="Verbose, ActivityTracing">
            <listeners>
              <add name="traceListener" type="System.Diagnostics.XmlWriterTraceListener" initializeData="d:\WcfMessageTrace.svclog" />
            </listeners>
          </source>
        </sources>
      </system.diagnostics>
      <system.serviceModel>
         <diagnostics>
          <messageLogging logEntireMessage="true" logMalformedMessages="true" logMessagesAtServiceLevel="true" logMessagesAtTransportLevel="true" />
        </diagnostics>
      </system.serviceModel>
 
    
