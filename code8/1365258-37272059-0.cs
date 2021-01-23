    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Xml.Schema;
    using System.IO;
    using OATAssetTracking.Solution.Presenter;
    namespace WindowsFormsApplication2
    {
    public class Program
    {
        static void Main()
        {
            string path2 = System.IO.Path.GetDirectoryName(
               System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + "SearchDefinition.xsd";
            string path1 = System.IO.Path.GetDirectoryName(
               System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + "SearchDefinition.xml";
            XmlSchema schema;
            using (var schemaReader = XmlReader.Create(path2))
            {
                schema = XmlSchema.Read(schemaReader, ValidationEventHandler);
            }
            var schemas = new XmlSchemaSet();
            schemas.Add(schema);
            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemas;
            settings.ValidationFlags =
                XmlSchemaValidationFlags.ProcessIdentityConstraints |
                XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += ValidationEventHandler;
            using (var validationReader = XmlReader.Create(path1, settings))
            {
                while (validationReader.Read())
                {
                }
            }
            MessageBox.Show("XML verified Successfully....");
            
            XmlSerializer ser = new XmlSerializer(typeof(Search));
            Search result = ser.Deserialize(new FileStream(path1, FileMode.Open)) as Search;
            MessageBox.Show("Deserilization Done Successfully!!!!");
            
        }
        private static void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Error)
            {
                throw args.Exception;
            }
         }
    }
    }
