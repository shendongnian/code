        public class InternationalizationAttribute : ActionFilterAttribute
        {
            /// <summary>
            /// The logger
            /// </summary>
            private NLog.Logger logger;
    
            private NLog.Logger Logger
            {
                get
                {
                    if (this.logger == null)
                    {
                        this.logger = NLog.LogManager.GetCurrentClassLogger();
                    }
    
                    return this.logger;
                }
            }
    
            /// <summary>
            /// Is called from the ASP.net framework before a method is executed
            /// </summary>
            /// <param name="filterContext">The filter context.</param>
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                string language = (string)filterContext.RouteData.Values["language"] ?? "de";
                string culture = (string)filterContext.RouteData.Values["culture"] ?? "DE";
    
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
                }
                catch (Exception ex)
                {
                    //// not supported culture, falling to default
                    this.Logger.Error(string.Format("Invalid culture '{0}-{1}', could not be set", language, culture), ex);
                }
            }
        }
    }
