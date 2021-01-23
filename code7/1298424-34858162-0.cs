    public class ISupportInitializeContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static ISupportInitializeContractResolver instance;
        // Using a static constructor enables fairly lazy initialization.  http://csharpindepth.com/Articles/General/Singleton.aspx
        static ISupportInitializeContractResolver() { instance = new ISupportInitializeContractResolver(); }
        public static ISupportInitializeContractResolver Instance { get { return instance; } }
        readonly SerializationCallback onDeserializing;
        readonly SerializationCallback onDeserialized;
        protected ISupportInitializeContractResolver()
            : base()
        {
            onDeserializing = (o, context) =>
                {
                    var init = o as ISupportInitialize;
                    if (init != null)
                        init.BeginInit();
                };
            onDeserialized = (o, context) =>
                {
                    var init = o as ISupportInitialize;
                    if (init != null)
                        init.EndInit();
                };
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);
            if (typeof(ISupportInitialize).IsAssignableFrom(objectType))
            {
                contract.OnDeserializingCallbacks.Add(onDeserializing);
                contract.OnDeserializedCallbacks.Add(onDeserialized);
            }
            return contract;
        }
    }
