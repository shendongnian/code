    public class RootNode
    {
       [XmlElement("IntroductionAction")]
       public List<IntroductionAction> introductionActions { get; set; }
       public RootNode()
       {
          introductionActions = new List<IntroductionAction>();
       }
       private static XmlAttributeOverrides GetXmlAttributeOverrides()
       {
          XmlAttributeOverrides xml_attr_overrides = new XmlAttributeOverrides();
          XmlAttributes xml_attrs = new XmlAttributes();
          xml_attrs.XmlElements.Add(new XmlElementAttribute(typeof(IntroductionActionComplex)));
          xml_attrs.XmlElements.Add(new XmlElementAttribute(typeof(IntroductionActionSimple)));
          xml_attr_overrides.Add(typeof(RootNode), "introductionActions", xml_attrs);
          return xml_attr_overrides;
       }
       // Add exception handling
       public static void SaveToFile(RootNode rootNode, string fileName)
       {
          using (MemoryStream mem_stream = new MemoryStream())
          {
             XmlSerializer serializer = new XmlSerializer(rootNode.GetType(), RootNode.GetXmlAttributeOverrides());
             serializer.Serialize(mem_stream, rootNode);
             using (BinaryWriter output = new BinaryWriter(new FileStream(fileName, FileMode.Create)))
             {
                output.Write(mem_stream.ToArray());
             }
          }
       }
       // Add exception handling
       public static RootNode LoadFromFile(string fileName)
       {
          if (File.Exists(fileName))
          {
             using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
             {
                using (TextReader reader = new StreamReader(file))
                {
                   XmlSerializer serializer = new XmlSerializer(typeof(RootNode), RootNode.GetXmlAttributeOverrides());
                   return (RootNode)serializer.Deserialize(reader);
                }
             }
          }
          return null;
       }
    }
