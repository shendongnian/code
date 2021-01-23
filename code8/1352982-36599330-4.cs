    namespace My.Application.Security
    {
        using My.Application.Diagnostics;
        using System;
        using System.Configuration;
        using System.Diagnostics;
        using System.Net;
        using System.Net.Http;
        using System.Threading;
        using System.Threading.Tasks;
        using System.Web.Cors;
        using System.Web.Http.Controllers;
        using System.Web.Http.Cors;
        using System.Web.Http.Filters;
    
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
        public class EnableWebApiCorsFromAppSettingsAttribute : ActionFilterAttribute, ICorsPolicyProvider
        {
            #region <Fields & Constants>
    
            private const string EXCEPTION_CONTEXT_NULL = "Access Denied: HttpActionContext cannot be null.";
            private const string EXCEPTION_REFERRER_NULL = "Access Denied: Referrer cannot be null.";
            private const string FORMAT_INVALID_REFERRER = "Access Denied: '{0}' is not a valid referrer.";
            private const string FORMAT_REFERRER = "Referrer: '{0}' was processed for this request.";
            private const string FORMAT_REFERRER_FOUND = "Referrer IsFound: {0}.";
    
            private readonly CorsPolicy policy;
    
            #endregion
    
            #region <Constructors>
    
            public EnableWebApiCorsFromAppSettingsAttribute(string appSettingKey, bool allowAnyHeader = true, bool allowAnyMethod = true, bool supportsCredentials = true)
            {
                policy = new CorsPolicy();
                policy.AllowAnyOrigin = false;
                policy.AllowAnyHeader = allowAnyHeader;
                policy.AllowAnyMethod = allowAnyMethod;
                policy.SupportsCredentials = supportsCredentials;
    
                SetValidOrigins(appSettingKey);
    
                if (policy.Origins.Count == 0)
                    policy.AllowAnyOrigin = true;
            }
    
            #endregion
    
            #region <Methods>
    
            #region public
    
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                TraceHandler.TraceIn(TraceLevel.Info);
    
                if (actionContext == null)
                    throw new ArgumentNullException("HttpActionContext");
    
                if (actionContext.Request.Headers.Referrer == null)
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, EXCEPTION_REFERRER_NULL);
    
                var referrer = actionContext.Request.Headers.Referrer.ToString();
    
                TraceHandler.TraceAppend(string.Format(FORMAT_REFERRER, referrer));
    
                // If no Origins Are Set - Do Nothing
                if (policy.Origins.Count > 0)
                {
                    var isFound = policy.Origins.Contains(referrer);
    
                    TraceHandler.TraceAppend(string.Format(FORMAT_REFERRER_FOUND, isFound));
    
                    if (!isFound)
                    {
                        TraceHandler.TraceAppend("IsFound was FALSE");
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, string.Format(FORMAT_INVALID_REFERRER, referrer));
                    }
                }
                  
                TraceHandler.TraceOut();
                base.OnActionExecuting(actionContext);
            }
    
            public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (cancellationToken.CanBeCanceled && cancellationToken.IsCancellationRequested)
                    return Task.FromResult<CorsPolicy>(null);
    
                return Task.FromResult(policy);
            }
    
            #endregion
    
            #region private
    
            private void SetValidOrigins(string appSettingKey)
            {
                // APP SETTING KEY: <add key="EnableCors.Origins" value="http://www.zippitydoodah.com" />
                var origins = string.Empty;
                if (!string.IsNullOrEmpty(appSettingKey))
                {
                    origins = ConfigurationManager.AppSettings[appSettingKey];
                    if (!string.IsNullOrEmpty(origins))
                    {
                        foreach (string origin in origins.Split(",;|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                            policy.Origins.Add(origin);
                    }
                }
            }
    
            #endregion
    
            #endregion
        }
    }
