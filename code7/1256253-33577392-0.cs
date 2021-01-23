    static void Main(string[] args)
    {
       List<string> strings = new List<string>();
       using (XmlReader reader = XmlReader.Create("file.xml"))
        {
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "chairs":
                            if (reader.Read())
                            {
                                strings.Add(reader.Value.Trim());
                            }
                            break;
                    }
                }
            }
        }
