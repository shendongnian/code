    using System.Linq;
    using System.Reflection;
    using System.Diagnostics;
    using System;
    
    namespace Helpers
    {
    	public class EmbeddedSourceror
        {
    		public static Xamarin.Forms.ImageSource SourceFor(string pclFilePathInResourceFormat)
    		{
    			var resources = typeof(EmbeddedSourceror).GetTypeInfo().Assembly.GetManifestResourceNames();
    			var resourceName = resources.Single(r => r.EndsWith(pclFilePathInResourceFormat, StringComparison.OrdinalIgnoreCase));
    			Debug.WriteLine("EmbeddedSourceror: resourceName string is " + resourceName);
    
    			return Xamarin.Forms.ImageSource.FromResource(resourceName);
    		}
        }
    }
