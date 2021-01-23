    <configuration>
       <system.diagnostics>
          <sources>
                <source name="System.ServiceModel" 
                        switchValue="Information, ActivityTracing"
                        propagateActivity="true">
                   <listeners>
                       <add name="traceListener" />
                   </listeners>
                </source>
                <source name="System.ServiceModel.MessageLogging">
                   <listeners>
                       <add name="traceListener" />
                   </listeners>
                </source>
                <source name="System.Runtime.Serialization" 
                        switchValue="Information">
                   <listeners>
                       <add name="traceListener" />
                   </listeners>
                </source>
          </sources>
          <sharedListeners>
              <add name="traceListener" 
                   type="System.Diagnostics.XmlWriterTraceListener" 
                   initializeData= "c:\log\Traces.svclog" />
          </sharedListeners>
        </system.diagnostics>
        <system.serviceModel>
            <diagnostics>
                <messageLogging 
                    logEntireMessage="true" 
                    logMessagesAtServiceLevel="true"
                    maxSizeOfMessageToLog="16777216"/>
            </diagnostics>    
        </system.serviceModel>
    </configuration>
