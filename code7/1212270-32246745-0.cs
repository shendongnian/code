    public class PersonResources
    {
        private static System.Resources.ResourceManager resourceMan;
        private static System.Globalization.CultureInfo resourceCulture;
        
        static PersonResources() {
            // shouldbe something like "MyAssembyName"
            string assemblyName = System.Configuration.ConfigurationManager.AppSettings["ResourceAssembly"];
            if (!string.IsNullOrEmpty(assemblyName)) {
                resourceAssembly = System.Reflection.Assembly.LoadWithPartialName(assemblyName);
                resourceName = resourceAssembly.GetName().Name + ".Resources.PersonResources";
            }
        }
        private static readonly System.Reflection.Assembly resourceAssembly;
        private static readonly string resourceName;
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (ReferenceEquals(resourceMan, null)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager(resourceName, resourceAssembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        public static string NameKey {
            get {
                return ResourceManager.GetString("NameKey", resourceCulture);
            }
        }
        public static string LastNameKey {
            get {
                return ResourceManager.GetString("LastNameKey", resourceCulture);
            }
        }
    }
