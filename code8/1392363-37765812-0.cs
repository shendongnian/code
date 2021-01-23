    public class ModifierContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        // See also https://stackoverflow.com/questions/33557737/does-json-net-cache-types-serialization-information
        static ModifierContractResolver instance;
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static ModifierContractResolver() { instance = new ModifierContractResolver(); }
        public static ModifierContractResolver Instance { get { return instance; } }
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            // Apply in reverse order so inherited types are applied after base types.
            foreach (var attr in objectType.GetCustomAttributes<JsonObjectContractModifierAttribute>(true).Reverse())
            {
                var modifier = (JsonObjectContractModifier)Activator.CreateInstance(attr.ContractModifierType, true);
                modifier.ModifyContract(objectType, contract);
            }
            return contract;
        }
    }
    public abstract class JsonObjectContractModifier
    {
        public abstract void ModifyContract(Type objectType, JsonObjectContract contract);
    }
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class JsonObjectContractModifierAttribute : System.Attribute
    {
        private readonly Type _contractModifierType;
        public Type ContractModifierType { get { return _contractModifierType; } }
        public JsonObjectContractModifierAttribute(Type contractModifierType)
        {
            if (contractModifierType == null)
            {
                throw new ArgumentNullException("contractModifierType");
            }
            if (!typeof(JsonObjectContractModifier).IsAssignableFrom(contractModifierType))
            {
                throw new ArgumentNullException(string.Format("{0} is not a subtype of {1}", contractModifierType, typeof(JsonObjectContractModifier)));
            }
            this._contractModifierType = contractModifierType;
        }    
    }
