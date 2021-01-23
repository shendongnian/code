    public class Book
    {
        public String title;
    }       
    
    public static void WriteXML()       
    {
        // First write something so that there is something to read ...
        var b = new Book { title = "Serialization Overview" };
        var writer = new System.Xml.Serialization.XmlSerializer(typeof(Book));
        var wfile = new System.IO.StreamWriter(@"c:\temp\SerializationOverview.xml");
        writer.Serialize(wfile, b);
        wfile.Close();
    }
    public void ReadXML()
        // Now we can read the serialized book ...
        System.Xml.Serialization.XmlSerializer reader = 
            new System.Xml.Serialization.XmlSerializer(typeof(Book));
        System.IO.StreamReader file = new System.IO.StreamReader(
            @"c:\temp\SerializationOverview.xml");
        Book overview =  (Book)reader.Deserialize(file);
        file.Close();
    
        Console.WriteLine(overview.title);    
    }
