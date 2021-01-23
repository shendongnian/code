    using System.Xml.Linq;
    string xml = "<Simulation><Pedestrian Name='Mother'><Initial_Position In_X='3' In_Y='3' /><Final_Position><First Fin_X='6' Fin_Y='6' Time='2' /></Final_Position></Pedestrian></Simulation>";
    XDocument doc = XDocument.Parse(xml);
    foreach (XElement pedestrian in doc.Root.Elements("Pedestrian"))
    {
        XElement initialPosition = pedestrian.Element("Initial_Position");
        string name = pedestrian.Attribute("Name").Value;
        string x = initialPosition.Attribute("In_X").Value;
        string y = initialPosition.Attribute("In_Y").Value;
        Console.WriteLine("Name - {0}.X - {1}.Y - {2}", name, x, y);
    }
    Console.ReadKey();
