    foreach(XElement xe in root.Elements("Whistle"))
    {
        if (xe.Attribute("Type").Value == "Red")
        {
            Console.WriteLine(xe.Attribute("Version").Value);
        }
    }
