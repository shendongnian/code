    public class XmlSerializerFactory : XmlOrderFreeSerializerFactory
    {
        static readonly XmlSerializerFactory instance;
        // Use a static constructor for lazy initialization.
        private XmlSerializerFactory()
            : base(new[] { typeof(Type2), typeof(Type1), typeof(TestClass), typeof(Type3) }) // These are the types in your client for which Order needs to be ignored whend deserializing
        {
        }
        static XmlSerializerFactory()
        {
            instance = new XmlSerializerFactory();
        }
        public static XmlSerializerFactory Instance { get { return instance; } }
    }
    public abstract class XmlOrderFreeSerializerFactory
    {
        readonly XmlAttributeOverrides overrides;
        readonly object locker = new object();
        readonly Dictionary<Type, XmlSerializer> serializers = new Dictionary<Type, XmlSerializer>();
        static void AddOverrideAttributes(Type type, XmlAttributeOverrides overrides)
        {
            if (type == null || type == typeof(object) || type.IsPrimitive || type == typeof(string))
                return;
            var mask = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
            foreach (var member in type.GetProperties(mask).Cast<MemberInfo>().Union(type.GetFields(mask)))
            {
                XmlAttributes overrideAttr = null;
                foreach (var attr in member.GetCustomAttributes<XmlElementAttribute>())
                {
                    overrideAttr = overrideAttr ?? new XmlAttributes();
                    overrideAttr.XmlElements.Add(new XmlElementAttribute { DataType = attr.DataType, ElementName = attr.ElementName, Form = attr.Form, IsNullable = attr.IsNullable, Namespace = attr.Namespace, Type = attr.Type });
                }
                foreach (var attr in member.GetCustomAttributes<XmlArrayAttribute>())
                {
                    overrideAttr = overrideAttr ?? new XmlAttributes();
                    overrideAttr.XmlArray = new XmlArrayAttribute { ElementName = attr.ElementName, Form = attr.Form, IsNullable = attr.IsNullable, Namespace = attr.Namespace };
                }
                if (overrideAttr != null)
                    overrides.Add(type, member.Name, overrideAttr);
            }
        }
        protected XmlOrderFreeSerializerFactory(IEnumerable<Type> types)
        {
            overrides = new XmlAttributeOverrides();
            foreach (var type in types.SelectMany(t => t.BaseTypesAndSelf()).Distinct())
            {
                AddOverrideAttributes(type, overrides);
            }
        }
        public XmlSerializer GetSerializer(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            lock (locker)
            {
                XmlSerializer serializer;
                if (!serializers.TryGetValue(type, out serializer))
                    serializers[type] = serializer = new XmlSerializer(type, overrides);
                return serializer;
            }
        }
    }
    public static class TypeExtensions
    {
        public static IEnumerable<Type> BaseTypesAndSelf(this Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }
    }
