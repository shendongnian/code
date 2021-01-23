    public class EmbeddedResources
    {
        public static Assembly self { get { return Assembly.GetExecutingAssembly(); } }
    
        public static Image image(string name)
        {
            Image result = null;
    
            // note: typeof(EmbeddedResources).Namespace will only work if EmbeddedResources is defined in the default namespace
            Stream res = self.GetManifestResourceStream(typeof(EmbeddedResources).Namespace + "." + name);
            Byte[] mem = new Byte[res.Length];
            MemoryStream ms = new MemoryStream(mem, true);
            res.CopyTo(ms);
            result = Image.FromStream(ms);
            return result;
        }
    
    }
