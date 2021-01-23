    public class MyType : BaseType
    {
        private Dictionary<string, object> _dict = null;
        public override Dictionary<string, object> Dict
        {
            get
            {
                if (_dict == null)
                {
                    _dict = InitializeDictionary();
                }
                return _dict;
            }
            set
            {
                _dict = value;
            }
        }
    }
