    public class ContextUserPatternConverter : PatternLayoutConverter
        {
            protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
            {
                var userName = string.Empty;
                var context = HttpContext.Current;
                if (context != null && context.User != null && context.User.Identity.IsAuthenticated)
                {
                    userName = context.User.Identity.Name;
                }
                else
                {
                    var threadPincipal = Thread.CurrentPrincipal;
                    if (threadPincipal != null && threadPincipal.Identity.IsAuthenticated)
                    {
                        userName = threadPincipal.Identity.Name;
                    }
                }
                if (string.IsNullOrEmpty(userName))
                {
                    //get app pool identity
                    userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                }
                writer.Write(userName);
            }
        }
