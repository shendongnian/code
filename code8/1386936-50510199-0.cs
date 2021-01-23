    using System.Linq;
    using System.Reflection;
    using Xamarin.Forms;
    using System.Diagnostics;
    
    namespace Helpers
    {
        public class EmbeddedSourceror
        {
    		public static ImageSource SourceFor(string pclFilePathInResourceFormat)
    		{
    			var resourceID = Assembly.GetExecutingAssembly().FullName.Split(',').FirstOrDefault() + "." + pclFilePathInResourceFormat;
    
    			Debug.WriteLine("EmbeddedSourceror: resourceID string is " + resourceID);
        		
    			return ImageSource.FromResource(resourceID);
    		}
        }
    }
