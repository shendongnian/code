    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;
    
     public static class AssemblyBindingRedirectHelper
        {
            private static FunctionRedirectBindings _redirects;
    
            public static void ConfigureBindingRedirects()
            {
                // Only load the binding redirects once
                if (_redirects != null)
                    return;
    
                _redirects = new FunctionRedirectBindings();
    
                foreach (var redirect in _redirects.BindingRedirects)
                {
                    RedirectAssembly(redirect);
                }
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
    
                    var targetPublicKeyToken = new AssemblyName("x, PublicKeyToken=" + bindingRedirect.PublicKeyToken).GetPublicKeyToken();
                    requestedAssembly.Version = new Version(bindingRedirect.RedirectToVersion);
                    requestedAssembly.SetPublicKeyToken(targetPublicKeyToken);
                    requestedAssembly.CultureInfo = CultureInfo.InvariantCulture;
    
                    AppDomain.CurrentDomain.AssemblyResolve -= handler;
    
                    return Assembly.Load(requestedAssembly);
                };
    
                AppDomain.CurrentDomain.AssemblyResolve += handler;
            }
        }
    
        public class FunctionRedirectBindings
        {
            public HashSet<BindingRedirect> BindingRedirects { get; } = new HashSet<BindingRedirect>();
    
            public FunctionRedirectBindings()
            {
                var assm = Assembly.GetExecutingAssembly();
                var bindingRedirectFileName = $"{assm.GetName().Name}.dll.config";
                var dir = Path.Combine(Environment.GetEnvironmentVariable("HOME"), @"site\wwwroot");
                var fullPath = Path.Combine(dir, bindingRedirectFileName);
    
                if(!File.Exists(fullPath))
                    throw new ArgumentException($"Could not find binding redirect file. Path:{fullPath}");
    
                var xml = ReadFile<configuration>(fullPath);
                TransformData(xml);
            }
    
            private T ReadFile<T>(string path)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    var obj = (T)serializer.Deserialize(reader);
                    reader.Close();
                    return obj;
                }
            }
    
            private void TransformData(configuration xml)
            {
                foreach(var item in xml.runtime)
                {
                    var br = new BindingRedirect
                    {
                        ShortName = item.dependentAssembly.assemblyIdentity.name,
                        PublicKeyToken = item.dependentAssembly.assemblyIdentity.publicKeyToken,
                        RedirectToVersion = item.dependentAssembly.bindingRedirect.newVersion
                    };
                    BindingRedirects.Add(br);
                }
            }
        }
    
        public class BindingRedirect
        {
            public string ShortName { get; set; }
            public string PublicKeyToken { get; set; }
            public string RedirectToVersion { get; set; }
        }
