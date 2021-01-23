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
                public static void ConfigureBindingRedirects()
                {
                    var config = Environment.GetEnvironmentVariable("BindingRedirects");
                    var cArray = JArray.Parse(config);
                    var redirects = cArray.Select(x => JsonConvert.DeserializeAnonymousType(x.ToString(), new { ShortName = "", RedirectToVersion = "", PublicKeyToken = "" })).ToList();
                    redirects.ForEach(x => RedirectAssembly(x.ShortName, x.RedirectToVersion, x.PublicKeyToken));
                }
                public static void RedirectAssembly(string shortName, string redirectToVersion, string publicKeyToken)
                {
                    ResolveEventHandler handler = null;
                    handler = (sender, args) =>
                    {
                        var requestedAssembly = new AssemblyName(args.Name);
                        if (requestedAssembly.Name != shortName)
                        {
                            return null;
                        }
                        var targetPublicKeyToken = new AssemblyName("x, PublicKeyToken=" + publicKeyToken)
                            .GetPublicKeyToken();
                        requestedAssembly.Version = new Version(redirectToVersion);
                        requestedAssembly.SetPublicKeyToken(targetPublicKeyToken);
                        requestedAssembly.CultureInfo = CultureInfo.InvariantCulture;
                        AppDomain.CurrentDomain.AssemblyResolve -= handler;
                        return Assembly.Load(requestedAssembly);
                    };
                    AppDomain.CurrentDomain.AssemblyResolve += handler;
                }
            }
        }
