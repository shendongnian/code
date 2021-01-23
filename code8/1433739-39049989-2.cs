    public class EmbeddedResources
    {
        public static Assembly self { get { return Assembly.GetExecutingAssembly(); } }
    
        public static Image image(string name)
        {
            Image result = null;
    
            // note: typeof(EmbeddedResources).Namespace will only work if EmbeddedResources is defined in the default namespace
            Stream res = self.GetManifestResourceStream(typeof(EmbeddedResources).Namespace + "." + name);
            result = Image.FromStream(res);
            return result;
        }
    
    }
