    public class XmlSynonymDeserializer : XmlSerializer
    {
        public class SynonymsAttribute : Attribute
        {
            public readonly ISet<string> Names;
            public SynonymsAttribute(params string[] names)
            {
                this.Names = new HashSet<string>(names);
            }
            public static MemberInfo GetMember(object obj, string name)
            {
                Type type = obj.GetType();
                var result = type.GetProperty(name);
                if (result != null)
                    return result;
                foreach (MemberInfo member in type.GetProperties().Cast<MemberInfo>().Union(type.GetFields()))
                    foreach (var attr in member.GetCustomAttributes(typeof(SynonymsAttribute), true))
                        if (attr is SynonymsAttribute && ((SynonymsAttribute)attr).Names.Contains(name))
                            return member;
                return null;
            }
        }
        
        public XmlSynonymDeserializer(Type type)
            : base(type)
        {
            this.UnknownElement += this.SynonymHandler;
        }
        public XmlSynonymDeserializer(Type type, XmlRootAttribute root)
            : base(type, root)
        {
            this.UnknownElement += this.SynonymHandler;
        }
        protected void SynonymHandler(object sender, XmlElementEventArgs e)
        {
            var member = SynonymsAttribute.GetMember(e.ObjectBeingDeserialized, e.Element.Name);
            Type memberType;
            if (member != null && member is FieldInfo)
                memberType = ((FieldInfo)member).FieldType;
            else if (member != null && member is PropertyInfo)
                memberType = ((PropertyInfo)member).PropertyType;
            else
                return;
            if (member != null)
            {
                object value;
                XmlSynonymDeserializer serializer = new XmlSynonymDeserializer(memberType, new XmlRootAttribute(e.Element.Name));
                using (System.IO.StringReader reader = new System.IO.StringReader(e.Element.OuterXml))
                    value = serializer.Deserialize(reader);
                if (member is FieldInfo)
                    ((FieldInfo)member).SetValue(e.ObjectBeingDeserialized, value);
                else if (member is PropertyInfo)
                    ((PropertyInfo)member).SetValue(e.ObjectBeingDeserialized, value);
            }
        }
    }
