    using System;
    using System.Xml;
    using System.Xml.Schema;
    class XMLSchemaExamples
    {
        public static void Main()
        {
            XmlSchema schema = new XmlSchema();
            var ct = new XmlSchemaComplexType {Name = "Sensor_Info"};
            schema.Items.Add(ct);
            var at = new XmlSchemaAttribute
            {
                Name = "count",
                SchemaTypeName = new XmlQualifiedName("int", XmlSchema.Namespace)
            };
            ct.Attributes.Add(at);
            var seq = new XmlSchemaSequence();
            ct.Particle = seq;
            var sensor = new XmlSchemaElement {Name = "Sensor", MaxOccursString = "unbounded"};
            seq.Items.Add(sensor);
            var sensorType = new XmlSchemaComplexType();
            sensor.SchemaType = sensorType;
            at = new XmlSchemaAttribute
            {
                Name = "id",
                SchemaTypeName = new XmlQualifiedName("string", XmlSchema.Namespace)
            };
            sensorType.Attributes.Add(at);
            // TODO add more attributes here
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.ValidationEventHandler += ValidationCallbackOne;
            schemaSet.Add(schema);
            schemaSet.Compile();
       
            var nsmgr = new XmlNamespaceManager(new NameTable());
            nsmgr.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
            schema.Write(Console.Out, nsmgr);
        }
        public static void ValidationCallbackOne(object sender, ValidationEventArgs args)
        {
            Console.WriteLine(args.Message);
        }
    }
