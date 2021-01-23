    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class InsightsReportMiddleware
    {
        readonly AppFunc next;
        readonly TelemetryClient telemetryClient;
        public InsightsReportMiddleware(AppFunc next, TelemetryClient telemetryClient)
        {
            if (next == null)
            {
                throw new ArgumentNullException("next");
            }
            this.telemetryClient = telemetryClient;
            this.next = next;
        }
        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);
            var rt = new RequestTelemetry()
            {
                Url = ctx.Request.Uri,
                HttpMethod = ctx.Request.Method,
                Name = ctx.Request.Path.ToString(),
                Timestamp = DateTimeOffset.Now
            };
            environment.Add("requestTelemetry", rt);
            var sw = new Stopwatch();
            sw.Start();
		    await next(environment);
            sw.Stop();
            rt.ResponseCode = ctx.Response.StatusCode.ToString();
            rt.Success = ctx.Response.StatusCode < 400;
            rt.Duration = sw.Elapsed;
            telemetryClient.TrackRequest(rt);
        }
    }
    public class InsightsExceptionLogger : ExceptionLogger
    {
        readonly TelemetryClient telemetryClient;
        public InsightsExceptionLogger(TelemetryClient telemetryClient)
        {
            this.telemetryClient = telemetryClient;            
        }
        public override Task LogAsync(ExceptionLoggerContext context, System.Threading.CancellationToken cancellationToken)
        {
            var owinContext = context.Request.GetOwinEnvironment();
            ExceptionTelemetry exceptionTelemetry = null;
            if (owinContext != null)
            {
                object obj;
                if (owinContext.TryGetValue("requestTelemetry", out obj))
                {
                    var requestTelemetry = obj as RequestTelemetry;
                    exceptionTelemetry = new ExceptionTelemetry(context.Exception)
                    {
                        Timestamp = DateTimeOffset.Now
                    };
                    exceptionTelemetry.Context.Operation.Id = requestTelemetry.Id;
                }
            }
            if (exceptionTelemetry != null)
            {
                telemetryClient.TrackException(exceptionTelemetry);
            }
            else
            {
                telemetryClient.TrackException(context.Exception);                
            }
            return Task.FromResult<object>(null);
        }
        public override void Log(ExceptionLoggerContext context)
        {
            telemetryClient.TrackException(context.Exception);
        }
    }
