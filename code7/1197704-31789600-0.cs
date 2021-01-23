    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
    
    x.Serialize(Console.Out,p);
    Console.WriteLine();
    Console.ReadLine();
