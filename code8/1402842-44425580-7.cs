    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    namespace Rackspace.AzureFunctions
    {
        public static class FunctionUtilities
            {
                public class BindingRedirect
                {
                    public string ShortName { get; set; }
                    public string PublicKeyToken { get; set; }
                    public string RedirectToVersion { get; set; }
                }
                
                public static void ConfigureBindingRedirects()
                {
                    var config = Environment.GetEnvironmentVariable("BindingRedirects");
                    var redirects = JsonConvert.DeserializeObject<List<BindingRedirect>>();
                    redirects.ForEach(RedirectAssembly);
                }
                public static void RedirectAssembly(BindingRedirect bindingRedirect)
                {
                    ResolveEventHandler handler = null;
                    handler = (sender, args) =>
                    {
                        var requestedAssembly = new AssemblyName(args.Name);
                        if (requestedAssembly.Name != bindingRedirect.ShortName)
                        {
                            return null;
                        }
                        var targetPublicKeyToken = new AssemblyName("x, PublicKeyToken=" + bindingRedirect.PublicKeyToken)
                            .GetPublicKeyToken();
                        requestedAssembly.Version = new Version(bindingRedirect.RedirectToVersion);
                        requestedAssembly.SetPublicKeyToken(targetPublicKeyToken);
                        requestedAssembly.CultureInfo = CultureInfo.InvariantCulture;
                        AppDomain.CurrentDomain.AssemblyResolve -= handler;
                        return Assembly.Load(requestedAssembly);
                    };
                    AppDomain.CurrentDomain.AssemblyResolve += handler;
                }
            }
        }
