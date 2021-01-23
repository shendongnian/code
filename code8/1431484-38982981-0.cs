    XmlSerializer serializer = new XmlSerializer(typeof(people));
    using (TextReader reader = new StringReader(json))
    {
        people person = (people) serializer.Deserialize(reader);
        List<peoplePerson> list = person.person.ToList();
        Console.WriteLine(list.Count); // Prints 4
    }
