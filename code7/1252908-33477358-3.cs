    using System;
    using System.Xml;
    using System.Reflection;
    using System.IO;
     
    namespace MyApp
    {
      public class EmbeddedResourceResolver : XmlUrlResolver
      {
        public override object GetEntity(Uri absoluteUri,
          string role, Type ofObjectToReturn)
        {
          Assembly assembly = Assembly.GetExecutingAssembly();
          return assembly.GetManifestResourceStream("the.path.to.your.resource");
        }
      }
    }
