    using System;
    using System.Threading;
    using Microsoft.ApplicationInsights;
    
    public static readonly TelemetryClient TelemetryClient = new  TelemetryClient(){ InstrumentationKey = "MyInstrumentationKey" };
    public static bool first = true;
    public static void Run(TimerInfo myTimer, TraceWriter log, CancellationToken token)
    {
        if(first){
            token.Register(() =>
            {
                TelemetryClient.TrackEvent("TelemetryClientFlush");
                TelemetryClient.Flush();
            });
            first = false;
        }
        
        TelemetryClient.TrackEvent("AzureFunctionTriggered");
        log.Verbose($"C# Timer trigger function executed at: {DateTime.Now}");
    }
