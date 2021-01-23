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
            XmlSerializer serializer = new XmlSerializer(typeof(ConcreteGenericModel), attrOverides);
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
                serializer.Serialize(writer, cgm);
            Console.WriteLine(sb.ToString());
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
