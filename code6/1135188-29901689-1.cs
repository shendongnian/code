    private static void Main(string[] args)
    {
        var eventData = new List<Gps.EventData>();
        for (int i = 0; i < 5; ++i)
        {
            eventData.Add(new Gps.EventData
            {
                Desc = "X", 
                Type = "Y",
                Gps = new Gps.GpsData
                {
                    Dte = DateTime.Now,
                    Id = i.ToString()
                }
            });
        }
    
        Gps gps = new Gps()
        {
            Head = new Gps.HeadData {Dte = DateTime.Now, Nemo = "XYS-XML"},
            Events = eventData
        };
    
    
        var serializer = new XmlSerializer(gps.GetType());
        using (var writer = new StreamWriter(@"C:\temp\gps.xml"))
        {
            serializer.Serialize(writer, gps);
        }
           
        Console.ReadLine();
    }
