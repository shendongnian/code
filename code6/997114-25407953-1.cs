    public class APIParser(string file)
    {
         // Person should be Xml Root Element.
         XmlSerializer serialize = new XmlSerializer(typeof(Person)); 
         using(FileStream stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
              using(XmlReader reader XmlReader.Create(stream))
              {
                  Person model = serialize.Deserialize(reader) as Person;
              }
    }
