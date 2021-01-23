    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                //alternate method
                //DataSet ds = new DataSet();
                //ds.ReadXml(FILENAME);
     
                XmlSerializer xs = new XmlSerializer(typeof(LabelsSets));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                LabelsSets labelSets = (LabelsSets)xs.Deserialize(reader);
            }
        }
        
    }
    [XmlRoot("labelsSets")]
    public class LabelsSets
    {
        [XmlElement("labelsSet")]
        public List<LabelsSet> labelSet {get;set;}
    }
    [XmlRoot("labelsSet")]
    public class LabelsSet
    {
        [XmlAttribute("getUrl")]
        public string getUrl {get;set;}
        [XmlElement("fields")]
        public Fields fields {get;set;}
    }
    [XmlRoot("fields")]
    public class Fields
    {
        [XmlElement("field")]
        public List<Field> fields {get;set;}
    }
    [XmlRoot("field")]
    public class Field
    {
        [XmlAttribute("name")]
        public string name {get;set;}
        [XmlAttribute("required")]
        public Boolean required {get;set;}
        [XmlAttribute("xPath")]
        public string xPath {get;set;}
        [XmlAttribute("doGet")]
        public Boolean doGet {get;set;}
        [XmlAttribute("isRoot")]
        public Boolean isRoot {get;set;}
    }
