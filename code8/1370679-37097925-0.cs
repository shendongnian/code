    using log4net;
    using System.Linq;
    using System.Threading.Tasks;
    using WcfClientProxyGenerator;
    using Silly.Services.CarPark.Logging;
    namespace Silly.Services.Carpark
    {
        public class ClientBase<TClient> where TClient : class
        {
            private static Log4NetLoggingAdapter systemLogger;
            private static TClient proxy;
            public ClientBase(string binding)
            {
                if (systemLogger == null)
                {
                    LoggerSetup.Configure(Constants.ModuleNameForLogging);
                    systemLogger = new Log4NetLoggingAdapter(LogManager.GetLogger(this.GetType()));
                }
                proxy = WcfClientProxy.Create<TClient>(c =>
                {
                    c.SetEndpoint(binding);
                    c.OnCallBegin += (sender, args) => { };
                    c.OnBeforeInvoke += (sender, args) =>
                    {
                        systemLogger.Write(string.Format("{0}.{1} called with parameters: {2}", args.ServiceType.Name, args.InvokeInfo.MethodName, string.Join(", ", args.InvokeInfo.Parameters)), Core.EventSeverity.Verbose);
                    };
                    c.OnAfterInvoke += (sender, args) =>
                    {
                        systemLogger.Write(string.Format("{0}.{1} returned value: {2}", args.ServiceType.Name, args.InvokeInfo.MethodName, args.InvokeInfo.ReturnValue), Core.EventSeverity.Verbose);
                    };
                    c.OnCallSuccess += (sender, args) =>
                    {
                        systemLogger.Write(string.Format("{0}.{1} completed successfully", args.ServiceType.Name, args.InvokeInfo.MethodName));
                    };
                    c.OnException += (sender, args) =>
                    {
                        systemLogger.Write(string.Format("Exception during service call to {0}.{1}: {2}", args.ServiceType.Name, args.InvokeInfo.MethodName, args.Exception.Message), args.Exception, Core.EventSeverity.Error);
                    };
                });
            }
            // The following class property exposes static private var
            // to derived classes, as read-only. 
            protected TClient Proxy { get { return proxy; } }
        }
    }
