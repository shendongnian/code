    /// <summary>
    /// The <see cref="RouteParameter"/> class can be used to indicate properties about a route parameter (the literals and placeholders 
    /// located within segments of a <see cref="M:IHttpRoute.RouteTemplate"/>). 
    /// It can for example be used to indicate that a route parameter is optional.
    /// </summary>
    public sealed class RouteParameter
    {
        public static readonly RouteParameter Optional = new RouteParameter();
        // singleton constructor
        private RouteParameter()        {   }
        public override string ToString()   {  return string.Empty;      }
    }
