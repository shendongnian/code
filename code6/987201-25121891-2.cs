    foreach(DictionaryEntry de in e.NewValues())
    {
        string name = de.FirstOrDefault(x => x.Key == "name").Value;
        string phone = de.FirstOrDefault(x => x.Key == "phone").Value;
        string email = de.FirstOrDefault(x => x.Key == "email").Value;
    }
