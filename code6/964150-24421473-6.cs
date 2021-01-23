        void test()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<BODY><p><li>bla bla</li></p><h1><p2>bla bla</p2></h1><xyz>bla bla<p3>bla bla</p3>bla bla</xyz><abc><p3>bla bla</p3></abc></BODY>");
            MyXMLWriter writer = new MyXMLWriter("c:\\out.xml");
            doc.Save(writer);
            writer.Flush();
            writer.Close();
        }
        public class MyXMLWriter : XmlTextWriter
        {
            Stack<string> elementStack = new Stack<string>();
            public static string[] notAllowedTags = new string[] { "xyz", "abc" };
            public MyXMLWriter(string fileName)
                : base(fileName, Encoding.UTF8)
            {
            }
            public override void WriteStartElement(string prefix, string localName, string ns)
            {
                if (!notAllowedTags.Contains(localName))
                {
                    base.WriteStartElement(prefix, localName, ns);
                }
                elementStack.Push(localName);
            }
            public override void WriteFullEndElement()
            {
                string tagLocalName = elementStack.Pop();
                if (!notAllowedTags.Contains(tagLocalName))
                {
                    base.WriteFullEndElement();
                }
            }
            public override void WriteEndElement()
            {
                string tagLocalName = elementStack.Pop();
                if(!notAllowedTags.Contains(tagLocalName))
                {
                    base.WriteEndElement();
                }
            }
        }
