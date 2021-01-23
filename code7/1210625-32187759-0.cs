    public class SharedData
    {
        internal static string GlobMeta;
        internal static int GlobValue;
        
        public SharedData(string meta, int value)
        {
            GlobMeta = meta;
            GlobValue = value;
        }
    
        public SharedData(){}
    }
    
    public class DerivedData: SharedData
    {
        public DerivedData() : base()
        {
            Console.WriteLine("Shared meta = {0}, Shared Value = {1}", GlobMeta, GlobValue);
        }
    }
