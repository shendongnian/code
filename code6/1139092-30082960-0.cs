    public interface INancyContextWrapper
    {
        NancyContext Context { get; set; }
    }
    
    public class NancyContextWrapper : INancyContextWrapper
    {
        private NancyContext _context;
        public NancyContext Context 
        { 
               get {return _context;} 
               set {_context = value;} //do something here if you want to prevent repeated sets
        }
    }
