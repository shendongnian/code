	// Log error to the Event Log
	Exception myError = null;
	if (HttpContext.Current.Server.GetLastError() != null)
	{
		var request = HttpContext.Current.Request;
		myError = HttpContext.Current.Server.GetLastError();
		var dateAsBytes = System.Text.Encoding.UTF8.GetBytes(DateTime.Now.ToString("G"));
		var id = Convert.ToBase64String(System.Security.Cryptography.MD5.Create().ComputeHash(dateAsBytes));
		// Event info:
		var eventMessage = myError.Message;
		var currentTime = DateTime.Now.ToString("G");
		var currentTimeUTC = DateTime.UtcNow.ToString("G");
		// Application info:
		var appDomainName = AppDomain.CurrentDomain.FriendlyName;
		var appDomainTrustLevel = (AppDomain.CurrentDomain.IsFullyTrusted) ? "Full" : "Partial";
		var appVirtualPath = VirtualPathUtility.GetDirectory(request.Path);
		var appPath = request.PhysicalApplicationPath;
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
		// Request info:
		var url = request.Url.AbsoluteUri;
		var urlPath = request.Url.PathAndQuery;
		var remoteAddress = request.UserHostAddress;
		var userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
		var isAuthenticated = HttpContext.Current.User.Identity.IsAuthenticated;
		var authenticationType = System.Security.Principal.WindowsIdentity.GetCurrent().AuthenticationType;
		// Thread info:
		var impersonationLevel = System.Security.Principal.WindowsIdentity.GetCurrent().ImpersonationLevel;
		var exceptionStack2 = myError.StackTrace;
        // TODO: aggregate all info as string before writting to EventLog.
	}
