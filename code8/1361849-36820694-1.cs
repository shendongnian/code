    using (var reader = XmlReader.Create(path))
    {
        while (reader.ReadToFollowing("Sender", ns))
        {
            using (var innerReader = reader.ReadSubtree())
            {
                if (innerReader.ReadToFollowing("name", ns))
                {
                    string name = reader.ReadElementContentAsString();
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
