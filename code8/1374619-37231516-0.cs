    public class HttpLogfileProvider : ILogFileProvider
    {
         public string PathToLogfile => 
            Path.Combine(HttpContext.Current.Request.UserHostAddress, "log.txt");
    }
