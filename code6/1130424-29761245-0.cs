    public class MyClass
    {
        public System.Windows.Size WSize = new System.Windows.Size();
        public System.Drawing.Size DSize = new System.Drawing.Size();
    }
    public class MyClassProxy : MyClass, IXmlSerializable
    {
        public new System.Windows.Size WSize { get { return base.WSize; } set { base.WSize = value; } }
        public new System.Drawing.Size DSize { get { return base.DSize; } set { base.DSize = value; } }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToContent();
            reader.ReadStartElement();
            string wheight = reader["height"];
            string wwidth = reader["width"];
            int w, h;
            w = int.Parse(wwidth);
            h = int.Parse(wheight);
            WSize = new Size(w, h);
            reader.ReadStartElement();
            string dheight = reader["height"];
            string dwidth = reader["width"];
            w = int.Parse(dwidth);
            h = int.Parse(dheight);
            DSize = new System.Drawing.Size(w, h);
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("MyClassProxy");
            writer.WriteStartElement("WSize");
            writer.WriteAttributeString("height", WSize.Height.ToString());
            writer.WriteAttributeString("width", WSize.Width.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("DSize");
            writer.WriteAttributeString("height", DSize.Height.ToString());
            writer.WriteAttributeString("width", DSize.Width.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClassProxy p = new MyClassProxy();
            p.DSize = new System.Drawing.Size(100, 100);
            p.WSize = new Size(400, 400);
            string xml = "";
            using (StringWriter sw = new StringWriter())
            {
                System.Xml.XmlWriter wr = System.Xml.XmlWriter.Create(sw);
                p.WriteXml(wr);
                wr.Close();
                xml = sw.ToString();
            }
            MyClassProxy p2 = new MyClassProxy();
            using (StringReader sr = new StringReader(xml))
            {
                System.Xml.XmlReader r = System.Xml.XmlReader.Create(sr);
                p2.ReadXml(r);
            }
            MyClass baseClass = (MyClass)p2;
            Print(baseClass);
            Console.ReadKey();
        }
        static void Print(MyClass c)
        {
            Console.WriteLine(c.DSize.ToString());
            Console.WriteLine(c.WSize.ToString());
        }
    
    }
