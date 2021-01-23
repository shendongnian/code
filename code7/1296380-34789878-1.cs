    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1 {
        internal class Program {
            private static void Main(string[] args) {
                var xml = @"<RSA>
      <Size>
        <Name>0005-24</Name>
        <IDs>
          <ID>0005</ID>
          <ID>0009</ID>
        </IDs>
      </Size>
      <Size>
        <Name>0005-24</Name>
        <IDs>
          <ID>0003</ID>
          <ID>0004</ID>
          <ID>0005</ID>
          <ID>0006</ID>
          <ID>0007</ID>
          <ID>0008</ID>
          <ID>0010</ID>
          <ID>0009</ID>
        </IDs>
      </Size>
      <Size>
        <Name>0015-24</Name>
        <IDs>
          <ID>0003</ID>
          <ID>0004</ID>
          <ID>0005</ID>
          <ID>0006</ID>
          <ID>0007</ID>
          <ID>0008</ID>
          <ID>0010</ID>
          <ID>0009</ID>
          <ID>0034</ID>
          <ID>0078</ID>
        </IDs>
      </Size>
      <Size>
        <Name>003-12</Name>
        <IDs>
          <ID>0003</ID>
          <ID>0004</ID>
          <ID>0005</ID>
          <ID>0006</ID>
          <ID>0007</ID>
          <ID>0008</ID>
          <ID>0010</ID>
          <ID>0009</ID>
        </IDs>
      </Size>
    </RSA>";
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                var reader = new XmlTextReader(stream);
                var root = XElement.Load(reader);
    
                var names = root.Elements("Size") // Get each top level size element to make the query more efficient
                    .GroupBy(r => r.Element("Name").Value, // Group by the name element
                        (key, Ids) => new {
                            Name = key,
                            Ids = Ids.SelectMany(x => x.Element("IDs").Elements("ID").Select(e => e.Value)).Distinct()
                        }) // project to new form and evaluate the group
                    .OrderBy(x => x.Name); // Order by the top level grouping
    
                foreach(var name in names) {
                    Console.Write((string.Concat("Name: ", name.Name, " - ")));
                    foreach(var id in name.Ids.OrderBy(x => int.Parse(x))) {
                        // Order by the integer representation (needs additional checking with TryParse())
                        Console.Write(string.Concat(id, ", "));
                    }
                    Console.WriteLine();
                }
    
                Console.ReadLine();
            }
        }
    }
