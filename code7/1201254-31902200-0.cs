    public interface IMeta1
    {
       int Metaproperty1 {get; set;}
    }
    public interface IMeta2
    {
       int Metaproperty2 {get; set;}
    }
    public interface IMeta3
    {
       int Metaproperty3 {get; set;}
    }
    public class MetaComposite : IMeta1, IMeta2, IMeta3
    {
        private readonly Meta1 _meta1;
        private readonly Meta2 _meta2;
        private readonly Meta3 _meta3;
        public MetaComposite()
        {
            _meta1 = new Meta1();
            _meta2 = new Meta2();
            _meta3 = new Meta3();
        }
        public int Property1 
        {
            get { return _meta1.Property1; }
            set { _meta1.Property1 = value; }
        }
        public int Property2 
        {
            get { return _meta2.Property2; }
            set { _meta2.Property2 = value; }
        }
        public int Property3
        {
            get { return _meta3.Property3; }
            set { _meta3.Property3 = value; }
        }
    }
