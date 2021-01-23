    <configuration>
        <configSections>
            <section name="exceptionHandling" type="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.ExceptionHandlingSettings, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
            <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
        </configSections>
        <exceptionHandling>
            <exceptionPolicies>
                <add name="Policy">
                    <exceptionTypes>
                        <add name="All Exceptions" type="System.Exception, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                            postHandlingAction="NotifyRethrow">
                            <exceptionHandlers>
                                <add name="Logging Exception Handler" type="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging.LoggingExceptionHandler, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                                    logCategory="General" eventId="100" severity="Error" title="Enterprise Library Exception Handling"
                                    formatterType="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.TextExceptionFormatter, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling"
                                    priority="0" />
                            </exceptionHandlers>
                        </add>
                    </exceptionTypes>
                </add>
            </exceptionPolicies>
        </exceptionHandling>
        <loggingConfiguration name="" tracingEnabled="true" defaultCategory="General">
            <listeners>
                <add name="Event Log Listener" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.FormattedEventLogTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.FormattedEventLogTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    source="Enterprise Library Logging" formatter="Text Formatter"
                    log="" machineName="." traceOutputOptions="None" />
                <add name="Flat File Trace Listener" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.FlatFileTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.FlatFileTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    fileName="trace.log" />
            </listeners>
            <formatters>
                <add type="Microsoft.Practices.EnterpriseLibrary.Logging.Formatters.TextFormatter, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    template="Timestamp: {timestamp}{newline}
