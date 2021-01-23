    using System;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Schema;
    
    namespace Example
    {
        public class EmbeddedResourceResolver : XmlUrlResolver
        {
            public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                return assembly.GetManifestResourceStream("Example.Schema2.xsd");
            }
        }
    
        class Program
        {
            public static void Main()
            {
                XmlSchema schema1 = null;
    
                using (XmlTextReader xtr = new XmlTextReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Example.Schema1.xsd")))
                {
                    schema1 = XmlSchema.Read(xtr, new ValidationEventHandler(XSDValidationEventHandler));
                    xtr.Close();
                }
    
                XmlSchemaSet schemaSet = new XmlSchemaSet();
    
                schemaSet.XmlResolver = new EmbeddedResourceResolver();
                schemaSet.ValidationEventHandler += new ValidationEventHandler(XSDValidationEventHandler);
                schemaSet.Add(schema1);
    
                schemaSet.Compile();
    
                XmlSchema compiledSchema = null;
    
                foreach (XmlSchema schema in schemaSet.Schemas())
                {
                    compiledSchema = schema;
                }
    
                Console.WriteLine("Finished");
                Console.ReadKey();
            }
    
            public static void XSDValidationEventHandler(object sender, ValidationEventArgs args)
            {
                Console.WriteLine(args.Message);
            }
        }
    }
