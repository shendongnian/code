    public class Base
    {
        private readonly Lazy<int> _ID;
    
        protected Base()
        {
            _ID = new Lazy<int>(() => GetType().MetadataToken);
        }
    
        public int ID
        {
            get
            {
                return _ID.Value;
            }
        }
    }
