    public sealed class XmlEnumWrapper
    {
        System.Enum value;
        Type type;
        [XmlAttribute("enumType")]
        public string XmlEnumType
        {
            get
            {
                if (Type == null)
                    return null;
                return Type.AssemblyQualifiedName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    Type = null;
                }
                else
                {
                    Type = Type.GetType(value);
                }
            }
        }
        public abstract class EnumWraperBase
        {
            public abstract System.Enum BaseValue { get; }
        }
        [XmlRoot("Wrapper")]
        public sealed class InnerEnumWraper<T> : EnumWraperBase
        {
            public InnerEnumWraper() { }
            public InnerEnumWraper(T value) { this.Value = value; }
            public T Value { get; set; }
            public override Enum BaseValue { get { return (System.Enum)(object)Value; } }
        }
        [XmlText]
        public string XmlValue
        {
            get
            {
                if (Value == null)
                    return null;
                var wrapper = Activator.CreateInstance(typeof(InnerEnumWraper<>).MakeGenericType(Type), new object[] { Value });
                return (string)wrapper.SerializeToXElement().Element("Value");
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    Value = null;
                }
                else if (Type == null)
                {
                    throw new InvalidOperationException("Type was not set");
                }
                else
                {
                    var xelement = new XElement("Wrapper", new XElement("Value", value.Trim()));
                    var wrapper = (EnumWraperBase)xelement.Deserialize(typeof(InnerEnumWraper<>).MakeGenericType(Type));
                    Value = (wrapper == null ? null : wrapper.BaseValue);
                }
            }
        }
        [XmlIgnore]
        public System.Enum Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                if (value != null)
                    type = value.GetType();
            }
        }
        [XmlIgnore]
        public Type Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value != null)
                {
                    if (!value.IsEnum || value.IsAbstract)
                        throw new ArgumentException();
                }
                this.type = value;
                if (this.value != null && this.type != this.value.GetType())
                    this.value = null;
            }
        }
        public override string ToString()
        {
            return value == null ? "" : value.ToString();
        }
    }
    public static class XmlExtensions
    {
        public static T LoadFromXML<T>(this string xmlString)
        {
            T returnValue = default(T);
            using (StringReader reader = new StringReader(xmlString))
            {
                object result = new XmlSerializer(typeof(T)).Deserialize(reader);
                if (result is T)
                {
                    returnValue = (T)result;
                }
            }
            return returnValue;
        }
        public static string GetXml(this object obj)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    new XmlSerializer(obj.GetType()).Serialize(xmlWriter, obj);
                return textWriter.ToString();
            }
        }
        public static object Deserialize(this XContainer element, Type type)
        {
            using (var reader = element.CreateReader())
            {
                return new XmlSerializer(type).Deserialize(reader);
            }
        }
        public static XElement SerializeToXElement<T>(this T obj)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
                new XmlSerializer(obj.GetType()).Serialize(writer, obj);
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
    }
