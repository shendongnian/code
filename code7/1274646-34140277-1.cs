        public static void SendServerErrMsg(string codeSection, Exception exSvr, HttpContext context, SeverityLevel lvl = SeverityLevel.Warning)
        {
            if (_config == null || !_config.EnableEmailAlerts)
                return;
            if (context != null && context.Request != null && context.Request.Url != null && context.Request.Url.IsLoopback && !_config.SendAlertsInDebugMode)
                return;
            if (context != null && context.IsDebuggingEnabled && !_config.SendAlertsInDebugMode)
                return;
            // Attempt to get the currently logged in user.
            System.Web.Security.MembershipUser curUsr = null;
            try
            { curUsr = System.Web.Security.Membership.GetUser(); }
            catch { } // If it fails, don't worry about it.
            // Set the message's subject line.
            string subject = _config.ApplicationName + " Exception - " + HttpUtility.HtmlEncode(codeSection);
            // Build the page body in a StringBuilder object.
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (context != null && context.Request != null)
                sb.AppendLine(string.Format("<h2>{0}</h2>", HttpUtility.HtmlEncode(context.Request.ApplicationPath)));
            sb.AppendLine("<p>The following exception has occurred:</p>");
            sb.AppendLine("<ul>");
            Exception innerEx = exSvr;
            while (innerEx != null)
            {
                sb.AppendLine(string.Format("<li>{0}</li>", HttpUtility.HtmlEncode(innerEx.Message)));
                innerEx = innerEx.InnerException;
            }
            sb.AppendLine("</ul>");
            sb.AppendLine("<p/>");
            if (exSvr.TargetSite != null)
                sb.AppendLine(string.Format("<p>Target Site: {0} {1} (in {2})</p>", exSvr.TargetSite.MemberType, exSvr.TargetSite.Name, exSvr.TargetSite.DeclaringType));
            else
                sb.AppendLine("<p>Target Site: N/A</p>");
            sb.AppendLine("<p/>");
            sb.AppendLine("<hr />");
            if (context != null && context.Request != null)
            {
                HttpRequest req = context.Request;
                sb.AppendLine("<p>");
                sb.AppendLine(string.Format("<div>Request URL: {0}</div>", HttpUtility.HtmlEncode(req.Url.ToString())));
                sb.AppendLine(string.Format("<div>Request Path: {0}</div>", HttpUtility.HtmlEncode(req.FilePath)));
                sb.AppendLine(string.Format("<div>User: {0}</div>", (curUsr != null) ? HttpUtility.HtmlEncode(curUsr.UserName) : "Unknown"));
                sb.AppendLine(string.Format("<div>User Host Address: {0}</div>", HttpUtility.HtmlEncode(req.UserHostAddress)));
                // We're going to try a reverse DNS search on the IP address.  Failover,
                //   just uses the UserHostName value from the HttpContext object.
                string hostName = null;
                try { hostName = System.Net.Dns.GetHostEntry(req.UserHostAddress).HostName; }
                catch { hostName = null; }
                if (hostName == null) hostName = req.UserHostName;
                sb.AppendLine(string.Format("<div>User Host Name: {0}</div>", HttpUtility.HtmlEncode(hostName)));
                sb.AppendLine(string.Format("<div>User Agent: {0}</div>", HttpUtility.HtmlEncode(req.UserAgent)));
                sb.AppendLine(string.Format("<div>Server Name: {0}</div>", (context.Server != null ? HttpUtility.HtmlEncode(context.Server.MachineName) : "Unknown")));
                sb.AppendLine(string.Format("<div>Request Identity: {0}</div>", (req.LogonUserIdentity != null ? HttpUtility.HtmlEncode(req.LogonUserIdentity.Name) : "Unknown")));
                sb.AppendLine("</p>");
                sb.AppendLine("<hr />");
            }
            sb.AppendLine("<p>Stack trace follows:</p>");
            Exception ex = exSvr;
            while (ex != null)
            {
                sb.AppendLine("<p>");
                sb.AppendLine(string.Format("<b>&gt;&gt;&nbsp;{0}:</b> {1} in {2}<br/>", ex.GetType().Name, HttpUtility.HtmlEncode(ex.Message), HttpUtility.HtmlEncode(ex.Source)));
                sb.AppendLine(HttpUtility.HtmlEncode(ex.StackTrace));
                sb.AppendLine("</p>");
                ex = ex.InnerException;
            }
            if (context!=null && context.Trace.IsEnabled)
            {
                sb.AppendLine("<hr />");
                sb.AppendLine("<p>Web Trace:</p>");
                sb.AppendLine(string.Format("<p>{0}</p>", HttpUtility.HtmlEncode(context.Trace.ToString())));
            }
            EmailHelper.SendEmail(GetAlertContacts(), subject.Trim(), sb.ToString().Trim(), true);
        }
