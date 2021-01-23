    static void Main()
    {
        List<Colonist> colonists = Parse();
    
    
        for (int i = 0; i < colonists.Count; i++)
        {
            Console.WriteLine("Colonist " + i.ToString() + " Shirt Color After: " + colonists[i].Clothing[0].Color.R.ToString() + ", " + colonists[i].Clothing[0].Color.G.ToString() + ", " + colonists[i].Clothing[0].Color.B.ToString() + ", " + colonists[i].Clothing[0].Color.A.ToString());
            Console.WriteLine("Colonist " + i.ToString() + " Coat Color After: " + colonists[i].Clothing[1].Color.R.ToString() + ", " + colonists[i].Clothing[1].Color.G.ToString() + ", " + colonists[i].Clothing[1].Color.B.ToString() + ", " + colonists[i].Clothing[1].Color.A.ToString());
        }
    
    }
    
    private static List<Colonist> Parse()
    {
        List<Colonist> colonists = new List<Colonist>();
    
        using (XmlTextReader reader = new XmlTextReader(File.OpenRead("XMLFile1.xml")))
        {
            while (reader.Read())
            {
                switch (reader.Name)
                {
                    case "Colonist":
                        var colonist = VisitColonist(reader);
                        colonists.Add(colonist);
                        break;
                }
            }
        }
    
        return colonists;
    }
    
    private static Colonist VisitColonist(XmlTextReader reader)
    {
        Colonist colonist = new Colonist();
    
        while (reader.Read())
        {
            if (reader.Name == "Colonist" && reader.NodeType == XmlNodeType.EndElement)
                break;
    
            switch(reader.Name)
            {
                case "BasicInfo":
                    VisitBasicInfo(reader, colonist);
                    break;
    
                case "OnSkin":
                    VisitOnSkin(reader, colonist);
                    break;
    
                case "Shell":
                    VisitShell(reader, colonist);
                    break;
            }
    
        }
    
        return colonist;
    }
    
    private static void VisitBasicInfo(XmlTextReader reader, Colonist colonist)
    {
        while (reader.MoveToNextAttribute())
        {
            switch(reader.Name)
            {
                case "Name":
                    var parts = reader.Value.Split(' ');
                    colonist.FirstName = parts[0];
                    colonist.NickName = parts[1];
                    colonist.LastName = parts[2];
                    break;
    
                case "Age":
                    colonist.Age = Int32.Parse(reader.Value);
                    break;
            }
        }
    }
    
    private static void VisitOnSkin(XmlTextReader reader, Colonist colonist)
    {
        Clothing clothing = new Clothing();
    
        while (reader.MoveToNextAttribute())
        {
            switch (reader.Name)
            {
                case "Color":
                    clothing.Color = GetColor(reader.Value);
                    break;
            }
        }
    
        colonist.Clothing[0] = clothing;
    }
    
    private static void VisitShell(XmlTextReader reader, Colonist colonist)
    {
        Clothing clothing = new Clothing();
    
        while (reader.MoveToNextAttribute())
        {
            switch (reader.Name)
            {
                case "Color":
                    clothing.Color = GetColor(reader.Value);
                    break;
            }
        }
    
        colonist.Clothing[1] = clothing;
    }
    
    private static Color GetColor(string colorValue)
    {
        var parts = colorValue.Split(',');
    
        Color color = new Color {
            R = Single.Parse(parts[0]),
            G = Single.Parse(parts[1]),
            B = Single.Parse(parts[2]),
            A = Single.Parse(parts[3])
        };
    
        return color;
    }
