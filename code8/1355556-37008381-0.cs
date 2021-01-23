    public static class UseAngularXSRFExtension
    {
        public const string XSRFFieldName = "X-XSRF-TOKEN";
    
        public static IApplicationBuilder UseAngularXSRF( this IApplicationBuilder builder )
        {
            return builder.Use( next => context =>
            {
                switch( context.Request.Method.ToLower() )
                {
                    case "post":
                    case "put":
                    case "delete":
                        if( context.Request.Headers.ContainsKey( XSRFFieldName ) )
                        {
                            var formFields = new Dictionary<string, StringValues>()
                            {
                                { XSRFFieldName, context.Request.Headers[XSRFFieldName] }
                            };
    
                            // this assumes that any POST, PUT or DELETE having a header
                            // which includes XSRFFieldName is coming from angular, so 
                            // overwriting context.Request.Form is okay (since it's not
                            // being parsed by MVC's internals anyway)
                            context.Request.Form = new FormCollection( formFields );
                        }
    
                        break;
                }
    
                return next( context );
            } );
        }
    }
