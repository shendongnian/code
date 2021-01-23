     public class GenericManager<T> where T: IBaseInterfaceofWhateverIRequestServiceAndTheRestDeriveFrom
        {
            private static Log4NetLoggingAdapter systemLogger;
            private static T proxy = null;
    
    private void BuildGenericManager<T>(){
    
    if (systemLogger == null)
                {
                    LoggerSetup.Configure(Constants.ModuleNameForLogging);
                    systemLogger = new Log4NetLoggingAdapter(LogManager.GetLogger(typeof(RequestManager)));
                }
                proxy = WcfClientProxy.Create<T>(c =>
                {
                    c.SetEndpoint("BasicHttpBinding_IRequestService");
    
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
    }
            public GenericManager()
            {
                BuildGenericManager<T>();
            }
    }
