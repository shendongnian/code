    [XmlRoot("Property")]//you can change this if required
    public class Property
    {
        Public List<Point> points{get;set;};
    }
    
    public class Point
    {
     public double Sqft{get;set;}
     public double price{get;set;}
     public string Product{get;set;}
    
    }
    public static void Main(string[] args) 
    { 
        Property p = new Property();
        p.Sqft = 4;
        p.Product= "Speaker";
        p.Price = 120;
        Serialize(p);
    }   
    static public void Serialize(Property p)
    { 
        XmlSerializer serializer = new XmlSerializer(typeof(p)); 
        using (TextWriter writer = new StreamWriter(@"C:\Xml.xml"))
        {
            serializer.Serialize(writer, p); 
        } 
    }
