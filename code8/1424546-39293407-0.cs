    // Log error to the Event Log
    Exception myError = null;
    if (HttpContext.Current.Server.GetLastError() != null)
    {
        myError = HttpContext.Current.Server.GetLastError();
        // Event info:
        var eventMessage = myError.Message;
        var currentTime = DateTime.Now;
        var currentTimeUTC = DateTime.UtcNow;
        // Application info:
        var appDomainName = AppDomain.CurrentDomain.FriendlyName;
        var appDomainTrustLevel = (AppDomain.CurrentDomain.IsFullyTrusted) ? "Full" : "Partial";
        var appVirtualPath = VirtualPathUtility.GetDirectory(HttpContext.Current.Request.Path);
        var appPath = HttpContext.Current.Request.PhysicalApplicationPath;
        var machineName = Environment.MachineName;
        // Process info:
        var process = Process.GetCurrentProcess();
        var processId = process.Id;
        var processName = process.ProcessName;
        var user = System.Security.Principal.WindowsIdentity.GetCurrent().User;
        var accountName = user.Translate(typeof(System.Security.Principal.NTAccount));
        // Exception info:
        var exceptionType = myError.GetType().FullName;
        var exceptionMessage = myError.Message;
        var exceptionStack = myError.StackTrace;
        // TODO: aggregate all info as string before writting to EventLog.
    }
