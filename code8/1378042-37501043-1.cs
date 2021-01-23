    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    using Newtonsoft.Json.Linq;
    using Owin;
    
    [assembly: Microsoft.Owin.OwinStartup(typeof(CKSource.CKFinder.Connector.Shaggy.Startup))]
    namespace CKSource.CKFinder.Connector.Shaggy
    {
        using FileSystem.Local;
        using Core;
        using Core.Authentication;
        using Config;
        using Core.Builders;
        using Core.Logs;
        using Host.Owin;
        using Logs.NLog;
        using KeyValue.EntityFramework;
    
        public class Startup
        {
            public void Configuration(IAppBuilder builder)
            {
                LoggerManager.LoggerAdapterFactory = new NLogLoggerAdapterFactory();
    
                RegisterFileSystems();
    
                builder.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = "ApplicationCookie",
                    AuthenticationMode = AuthenticationMode.Active
                });
    
                //replace connector path with yours
                builder.Map("/connector", SetupConnector);
            }
    
            private static void RegisterFileSystems()
            {
                FileSystemFactory.RegisterFileSystem<LocalStorage>();
            }
    
            private static void SetupConnector(IAppBuilder builder)
            {
                var keyValueStoreProvider = new EntityFrameworkKeyValueStoreProvider("CacheConnectionString");
                var authenticator = new ShaggysAuthenticator();
    
                var connectorFactory = new OwinConnectorFactory();
                var connectorBuilder = new ConnectorBuilder();
                var connector = connectorBuilder
                    .LoadConfig()
                    .SetAuthenticator(authenticator)
                    .SetRequestConfiguration(
                        (request, config) =>
                        {
                            config.LoadConfig();
                            config.SetKeyValueStoreProvider(keyValueStoreProvider);
                        })
                    .Build(connectorFactory);
    
                builder.UseConnector(connector);
            }
        }
    
        public class ShaggysAuthenticator : IAuthenticator
        {
            // this method makes an http request on the background to gather ASP's all session contents and returns a JSON object
            // if the request contains ASP's session cookie(s)
            private static JObject GetAspSessionState(ICommandRequest requestContext)
            {
                // building Cookie header with ASP's session cookies
                var aspSessionCookies = string.Join(";",
                    requestContext.Cookies.Where(cookie => cookie.Key.StartsWith("ASPSESSIONID"))
                        .Select(cookie => string.Join("=", cookie.Key, cookie.Value)));
    
                if (aspSessionCookies.Length == 0)
                {
                    // logs can be found in /ckfinder/App_Data/logs
                    LoggerManager.GetLoggerForCurrentClass().Info("No ASP session cookie found");
                    // don't make an extra request to the connector.asp, there's no session initiated
                    return new JObject();
                }
    
                //replace this URL with your connector.asp's
                var publicAspSessionConnectorUrl = new Uri("http://myaspwebsite.com/connector.asp");
                var localSafeAspSessionConnectorUrl = new UriBuilder(publicAspSessionConnectorUrl) { Host = requestContext.LocalIpAddress };
    
                using (var wCli = new WebClient())
                    try
                    {
                        wCli.Headers.Add(HttpRequestHeader.Cookie, aspSessionCookies);
                        wCli.Headers.Add(HttpRequestHeader.Host, publicAspSessionConnectorUrl.Host);
                        return JObject.Parse(wCli.DownloadString(localSafeAspSessionConnectorUrl.Uri));
                    }
                    catch (Exception ex) // returning an empty JObject object in any fault
                    {
                        // logs can be found in /ckfinder/App_Data/logs
                        LoggerManager.GetLoggerForCurrentClass().Error(ex);
                        return new JObject();
                    }
            }
    
            public Task<IUser> AuthenticateAsync(ICommandRequest commandRequest, CancellationToken cancellationToken)
            {
                var aspSessionState = GetAspSessionState(commandRequest);
    
                var roles = new List<string>();
                var isEditor = aspSessionState.GetNullSafeValue("isEditor", false);
                var isMember = aspSessionState.GetNullSafeValue("isMember", false);
    
                if (isEditor) roles.Add("editor");
                if (isMember) roles.Add("member");
    
                var isAuthenticated = isEditor || isMember;
                var user = new User(isAuthenticated, roles);
                return Task.FromResult((IUser)user);
            }
        }
    
        public static class JObjectExtensions
        {
            // an extension method to help case insensitive lookups with a default value to get avoid NullReferenceException
            public static T GetNullSafeValue<T>(this JObject jobj, string key, T defaultValue = default(T))
            {
                dynamic val = jobj.GetValue(key, StringComparison.OrdinalIgnoreCase);
                if (val == null) return defaultValue;
                return (T)val;
            }
        }
    }
