    class Program
        {
            static void Main(string[] args)
            {
                string xml = @"<root>
        <notesbydate>
           <notedate date=""1996 - 12 - 06T00: 00:00"">
                  <note>
                       <notedate> asdasd </notedate>
                  </note>
                </notedate>
                  <notedate date = ""1996-12-06T00:00:00"">
                       <note>
                        <notedate> asdasd </notedate>
                   </note>
                </notedate>
              </notesbydate>
       </root>";
    
                var xDoc = XElement.Parse(xml);
                XElement test = xDoc.Element("notesbydate");
                test.ReplaceWith(
                    new XElement("NewChild", "new content")
            );
            Console.ReadKey();
        }
    }
