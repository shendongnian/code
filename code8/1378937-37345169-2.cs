    var raw = @"<Parent>
         <info>
           <id>1234</id>
           <secondary_id>ABC-1234</secondary_id>
         </info>
    
           <child>Something</child>
           <child2>Something else</child2>
           <child3>Something else here</child3>
    
         <Summary>
           <text>1234</text>
         </Summary>
    </Parent>";
    var doc = XDocument.Parse(raw);
    
    //step 1
    var elements = doc.Root.Elements().Where(o => o.Name.LocalName.StartsWith("child"));
    
    //step 2
    var newElement = new XElement("info_2", elements);
    doc.Root.Element("info").AddAfterSelf(newElement);
    
    //step 3:
    elements.Remove();
    
    //print result
    Console.WriteLine(doc.ToString());
