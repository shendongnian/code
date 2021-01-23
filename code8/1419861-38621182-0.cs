    public class Extension
    {
        string _Extension = null;
        private Extension(string ext)
        {
            _Extension = ext;
        }
        public static Extension TXT 
        {
            get {  return new Extension(".txt"); }
        }
        public static Extension XML
        {
            get { return new Extension(".xml"); }
        }
        public override string ToString()
        {
            return _Extension;
        }
    }
