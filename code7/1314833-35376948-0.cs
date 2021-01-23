    class LocalHostTelemetryFilter : ITelemetryProcessor
        {
            private ITelemetryProcessor next;
            public LocalHostTelemetryFilter(ITelemetryProcessor next)
            {
                this.next = next;
            }
    
            public void Process(ITelemetry item)
            {
                var requestTelemetry = item as RequestTelemetry;
                if (requestTelemetry != null && requestTelemetry.Url.Host.ToLower() == "localhost")
                {
                    return;
                }
                else
                {
                    this.next.Process(item);
                }   
            }
        }
