    abstract class Base
    {
        protected Base()
        {
            var t = GetType();
            if (!channelMap.ContainsKey(t))
                channelMap[t] = GetDeclaredChannels(t);
            channels = channelMap[t];
        }
        // All derived children must declare channel constants in a (static) nested class.
        private const string ChannelClassName = "Channel";
        // Static cache which maps types to an array of declared channels.
        private static readonly Dictionary<Type, string[]> channelMap = new Dictionary<Type, string[]>();
        private readonly string[] channels;
        // Exposed read-only list of channels.
        public IReadOnlyCollection<string> Channels
        {
            get { return channels; }
        }
        public bool Contains(string s)
        {
            return channels != null && channels.Contains(s);
        }
        private static string[] GetDeclaredChannels(Type type)
        {
            var channelType = type.GetNestedType(ChannelClassName);
            if (channelType == null)
                return null; // no channels declared.
            return channelType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(f => f.IsLiteral && !f.IsInitOnly)
                .Select(f => f.GetValue(null) as string)
                .ToArray();
        }
    }
    class Derived : Base
    {
        public class Channel // may be static or not
        {
            public const string One = "test";
            public const string Two = "test2";
        }
    }
    class Derived2 : Base { }
    new Derived().Contains(Derived.Channels.ChannelOne); // true;
    new Derived2().Contains(Derived.Channels.ChannelOne); // false
