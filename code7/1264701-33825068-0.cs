    public class MyType : BaseType
    {
        public override Dictionary<string, object> Dict
        {
            get
            {
                return GetSomeDictionary();
            }
            set
            {
                DoSomethingWith(value);
            }
        }
    }
