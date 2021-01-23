    public class a
    {
        public a() {
            b = new List<b>();
            c = new c(this);
        }
    
        public List<b> b { get; set; }
    
        public c c { get; set; }
    }
    
    public class c
    {
        private a _a;
        public c(a _a) { this._a = _a; }
    
        public int count { get {  return a.b.Count; } }
    }
