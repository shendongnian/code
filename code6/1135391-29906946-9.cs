    public interface IApple { }
    
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IApple))]
    [Export(typeof(IApple))]
    /* ..repeat N times.. */
    [Export(typeof(IApple))]
    public class Apple : IApple 
    { 
        private static int appleCounter = 0;
        private int id;
    
        public Apple() 
        {
            this.id = ++appleCounter;
        }
    
        public override string ToString()
        {
            return "Apple #" + this.id.ToString();
        }
    }
    class Program
    {
        [ImportMany(typeof(IApple))]
        private IEnumerable<IApple> apples = null;
        
        public static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }
    
        void Run()
        {
            var catalog = new AssemblyCatalog(this.GetType().Assembly);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            apples.Dump();
        }
    }
