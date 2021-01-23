     XDocument doc = XDocument.Load(@"c:\Events\Import\events.xml");
             if(doc != null)
             {
                var elements =  from el in doc.Element("System").Elements()
                 where el.Name == ("EventID")
                 select el;
                 foreach (XElement item in elements)
	             {
                     Console.WriteLine(item.Value);
		 
	             }    
             }
             Console.ReadLine();
   
