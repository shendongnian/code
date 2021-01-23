    public class a
    {
        public a() {
            b = new List<b>();
            c = new c(b);
        }
    
        public List<b> b { get; set; }
    
        public c c { get; set; }
    }
    
    public class c
    {
        private b _b;
        public c(b _b) { this._b = _b; }
    
        public int count { get {  return _b.Count; } }
    }
