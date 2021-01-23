    public class NextIdGenerator : TableGenerator
    {
    }
    public class NextIdGeneratorDef : IGeneratorDef
    {
        public string Class
        {
            get { return typeof(NextIdGenerator).AssemblyQualifiedName; }
        }
        public object Params
        {
            get { return null; }
        }
        public Type DefaultReturnType
        {
            get { return typeof(int); }
        }
        public bool SupportedAsCollectionElementId
        {
            get { return true; }
        }
    }
