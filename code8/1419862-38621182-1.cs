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
        public override bool Equals(object obj)
        {
            var e = obj as Extension;
            if (e == null) return false;
            return e._Extension == this._Extension;
        }
        public override int GetHashCode()
        {
            return _Extension.GetHashCode();
        }
    }
