    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class JsonIncludeAtDepthAttribute : System.Attribute
    {
        public JsonIncludeAtDepthAttribute()
        {
        }
    }
    public class DepthPruningContractResolver : IContractResolver
    {
        readonly int depth;
        public DepthPruningContractResolver()
            : this(0)
        {
        }
        public DepthPruningContractResolver(int depth)
        {
            if (depth < 0)
                throw new ArgumentOutOfRangeException("depth");
            this.depth = depth;
        }
        [ThreadStatic]
        static DepthTracker currentTracker;
        static DepthTracker CurrentTracker { get { return currentTracker; } set { currentTracker = value; } }
        class DepthTracker : IDisposable
        {
            int isDisposed;
            DepthTracker oldTracker;
            public DepthTracker()
            {
                isDisposed = 0;
                oldTracker = CurrentTracker;
                currentTracker = this;
            }
            #region IDisposable Members
            public void Dispose()
            {
                if (0 == Interlocked.Exchange(ref isDisposed, 1))
                {
                    CurrentTracker = oldTracker;
                    oldTracker = null;
                }
            }
            #endregion
            public int Depth { get; set; }
        }
        abstract class DepthTrackingContractResolver : DefaultContractResolver
        {
            static DepthTrackingContractResolver() { } // Mark type with beforefieldinit.
            static SerializationCallback OnSerializing = (o, context) =>
            {
                if (CurrentTracker != null)
                    CurrentTracker.Depth++;
            };
            static SerializationCallback OnSerialized = (o, context) =>
            {
                if (CurrentTracker != null)
                    CurrentTracker.Depth--;
            };
            protected override JsonObjectContract CreateObjectContract(Type objectType)
            {
                var contract = base.CreateObjectContract(objectType);
                contract.OnSerializingCallbacks.Add(OnSerializing);
                contract.OnSerializedCallbacks.Add(OnSerialized);
                return contract;
            }
        }
        sealed class RootContractResolver : DepthTrackingContractResolver
        {
            // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
            // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
            // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
            // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
            static RootContractResolver instance;
            static RootContractResolver() { instance = new RootContractResolver(); }
            public static RootContractResolver Instance { get { return instance; } }
        }
        sealed class NestedContractResolver : DepthTrackingContractResolver
        {
            static NestedContractResolver instance;
            static NestedContractResolver() { instance = new NestedContractResolver(); }
            public static NestedContractResolver Instance { get { return instance; } }
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                if (property.AttributeProvider.GetAttributes(typeof(JsonIncludeAtDepthAttribute), true).Count == 0)
                {
                    property.Ignored = true;
                }
                return property;
            }
        }
        public static IDisposable CreateTracker()
        {
            return new DepthTracker();
        }
        #region IContractResolver Members
        public JsonContract ResolveContract(Type type)
        {
            if (CurrentTracker != null && CurrentTracker.Depth > depth)
                return NestedContractResolver.Instance.ResolveContract(type);
            else
                return RootContractResolver.Instance.ResolveContract(type);
        }
        #endregion
    }
