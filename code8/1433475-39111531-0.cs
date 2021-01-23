    public static class LogicalThreadContext  
    { 
        private const string KeyPrefix = "NLog.LogicalThreadContext"; 
    
        private static string GetCallContextKey(string key)
        {
            return string.Format("{0}.{1}", KeyPrefix, key);
        }
    
        private static string GetCallContextValue(string key)
        {
            return CallContext.LogicalGetData(GetCallContextKey(key)) as string ?? string.Empty;
        }
    
        private static void SetCallContextValue(string key, string value)
        {
            CallContext.LogicalSetData(GetCallContextKey(key), value);         
        }
    
        public static string Get(string item)
        {
            return GetCallContextValue(item);
        }
    
        public static string Get(string item, IFormatProvider formatProvider)
        {
            if ((formatProvider == null) && (LogManager.Configuration != null))
            {
                formatProvider = LogManager.Configuration.DefaultCultureInfo;
            }
    
            return string.Format(formatProvider, "{0}", GetCallContextValue(item));
        }
    
        public static void Set(string item, string value)
        {
            SetCallContextValue(item, value);
        }
    }
    [LayoutRenderer("mdlc2")]
    public class LogicalThreadContextLayoutRenderer : LayoutRenderer
    {
       [DefaultParameter]
       public bool Name {get;set;}
    
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(LogicalThreadContext.Get(Name, null));
        }
    }
    
    //or application_start for ASP.NET 4
    static void Main(string[] args) 
    { 
        //layout renderer
        ConfigurationItemFactory.Default.LayoutRenderers
              .RegisterDefinition("mdlc2", typeof(LogicalThreadContextLayoutRenderer ));
    }
