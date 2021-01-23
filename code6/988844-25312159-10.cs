    public class CustomErrorLogModule: Elmah.ErrorLogModule
    {
        public Boolean SomethingWasLogged { get; set; }
        protected override void OnLogged(Elmah.ErrorLoggedEventArgs args)
        {
            SomethingWasLogged = true;
            base.OnLogged(args);
        }
    
        protected override void LogException(Exception e, HttpContext context)
        {
            SomethingWasLogged = false;
            base.LogException(e, context);
            if (!SomethingWasLogged)
            {
                throw new InvalidOperationException("An error was not logged");
            }
        }
    }
