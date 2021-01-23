    using System.Xml.Linq;
    namespace ConsoleApplication99
    {
      class Program
      {
        static string FixXmlString(string value)
        {
          int namePos = value.IndexOf(" name ");
          if (namePos < 0) return value; // name not found
          int lastSpace = value.LastIndexOf(' ');
          int cutLength = lastSpace - namePos;
          return value.Remove(namePos, cutLength);
        }
        static void Main()
        {
          XDocument doc = XDocument.Load("test.xml");
          foreach (XElement x in doc.Descendants("report").Where(x => x.Attribute("active").Value == "True"))
          {
            var attribute = x.Attribute("raw_xml");
            if (attribute != null)
            {
              attribute.Value = FixXmlString(attribute.Value);
            }
          }
          doc.Save("new.xml");
        }
      }
    }
