    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteTemplate ct = new ConcreteTemplate() { SomeProperty = "hello" };
            ConcreteGenericModel cgm = new ConcreteGenericModel(ct);
            XmlAttributeOverrides attrOverides = new XmlAttributeOverrides();
            XmlAttributes attrs = new XmlAttributes() { XmlIgnore = true };
            attrOverides.Add(typeof(Model), "Template", attrs);
            Type[] extraTypes = new Type[0];
            XmlSerializer serializer = new XmlSerializer(typeof(ConcreteGenericModel), attrOverides, extraTypes, null, null);
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
                serializer.Serialize(writer, cgm);
            string serializedClass = sb.ToString();
            Console.WriteLine(serializedClass);
            ConcreteGenericModel deserializedCgm;
            using (StringReader reader = new StringReader(serializedClass))
                deserializedCgm = (ConcreteGenericModel)serializer.Deserialize(reader);
            Console.ReadLine();
        }
    }
    public abstract class Template
    {
        // Some properties and methods defined
        public virtual string SomeProperty { get; set; }
    }
    public abstract class Template<TTemplate> : Template where TTemplate : Template
    {
        // No new properties defined, but methods overriden
    }
    public class ConcreteTemplate : Template { }
    public abstract class Model
    {
        public Model() { }
        public Template Template { get; set; }
        public Model(Template t) { Template = t; }
        // More properties and methods
    }
    public class ConcreteModel : Model
    {
        public ConcreteModel(Template t) : base(t) { }
    }
    public abstract class Model<TModel, TTemplate> : Model
        where TModel : Model
        where TTemplate : Template
    {
        public Model() { }
        public new TTemplate Template { get { return (TTemplate)base.Template; } set { base.Template = value; } }
        public Model(TTemplate t) : base(t) { }
        // Override some methods but no new properties
    }
    public class ConcreteGenericModel : Model<ConcreteModel, ConcreteTemplate>
    {
        public ConcreteGenericModel() { }
        public ConcreteGenericModel(ConcreteTemplate t) : base(t) { }
    }
