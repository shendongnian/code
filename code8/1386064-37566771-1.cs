    Root root = new Root
    {
        Ratings = new Rating[]
        {
            new Rating { City = "A", Code = "A1", Value = "A++" },
            new Rating { City = "B", Code = "A2", Value = "A" },
            new Rating { City = "C", Code = "A3", Value = "AB" }
        }
    };
    string serializedString;
    XmlSerializer serializer = new XmlSerializer(typeof(Root));
    using (StringWriter stringWriter = new StringWriter())
    {
        serializer.Serialize(stringWriter, root);
        serializedString = stringWriter.ToString();
    }
