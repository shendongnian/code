    public class Colonist
    { 
        public HairDef HairDef { get; set; }
    
        public Colonist()
        {
            HairDef = new HairDef();
        }
    }
    
    
    private static void VisitHairDef(XmlTextReader reader, int i)
    {
        //ColHairDef hairDef = new ColHairDef();
    
        while (reader.MoveToNextAttribute())
        {
            switch (reader.Name)
            {
                case "DefName":
                    ColonistManager.Population[i].HairDef.DefName = reader.Value;
                    break;
    
                case "GraphicPath":
                    ColonistManager.Population[i].HairDef.GraphicPath = reader.Value;
                    break;
    
                case "HairGender":
                    string hair = reader.Value;
                    int hairGender = 0;
                    if (hair == "Any")
                    {
                        hairGender = 2;
                    }
                    else if (hair == "Female")
                    {
                        hairGender = 4;
                    }
                    else if (hair == "FemaleUsually")
                    {
                        hairGender = 3;
                    }
                    else if (hair == "MaleUsually")
                    {
                        hairGender = 1;
                    }
                    ColonistManager.Population[i].HairDef.HairGender = (HairGender)hairGender;
                    break;
    
                case "Label":
                    ColonistManager.Population[i].HairDef.Label = reader.Value;
                    break;
    
                case "Tags":
                    ColonistManager.Population[i].HairDef.HairTags = GetTags(reader.Value);
                    //ColonistManager.Population[i].HairDef = hairDef;
                    break;
            }
        }
    }
