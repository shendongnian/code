    using System;
    using System.Web;
    using System.Diagnostics;
    
    namespace WpJournalHttpHandler
    {
    	public class ContentAccessModule : IHttpModule
    	{
    		private EventLog eventLog;
    
    		public void Init(HttpApplication application)
    		{
    			application.AuthenticateRequest += Application_AuthenticateRequest;
    
    
    			if (!EventLog.SourceExists("WpJournal"))
    			{
    				EventLog.CreateEventSource("WpJournal", "WpJournalActivity");
    			}
    			eventLog = new EventLog {Source = "WpJournal"};
    			eventLog.WriteEntry("Application initialized.", EventLogEntryType.Information);
    		}
    
    		public void Dispose()
    		{
    			//Cleanup
    		}
    
    		private void Application_AuthenticateRequest(object source, EventArgs e)
    		{
    			HttpContext context = HttpContext.Current;
    			eventLog.WriteEntry("Authentication for " + context.Request.Url + " from " + context.Request.UserHostAddress, EventLogEntryType.Information);
    			if (context.Request.Url.ToString().Contains("protected"))
    			{
    				context.Response.Redirect("https://journal.emergentpublications.com/restricted-content/");
    			}
    		}
    
    		private bool IsValidIpAddress(string ipAddress)
    		{
    			return false;
    		}
    
    		private string IsSubscribed(HttpContext context)
    		{
    			return null;
    		}
    	}
    }
