     private static void Save()
        {
            var xWriter = new XmlTextWriter("Save1.xml", Encoding.UTF8);
            xWriter.WriteStartDocument();
            xWriter.Formatting = Formatting.Indented;
            xWriter.WriteStartElement("Variables");
    
                xWriter.WriteStartElement("Zombies");
                xWriter.WriteValue(Vars.zombies);
                xWriter.WriteEndElement();
    
                xWriter.WriteStartElement("Infected");
                xWriter.WriteValue(Vars.infected);
                xWriter.WriteEndElement();
    
                xWriter.WriteStartElement("Wolfs");
                xWriter.WriteValue(Vars.wolfs);
                xWriter.WriteEndElement();
    
            xWriter.WriteEndElement();
            xWriter.Close();
        }
