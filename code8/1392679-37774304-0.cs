    static IParser<Url> CreateParser(Url uri)
    {
        return new UrlPaqrser<Url>();
    }
    
    static IParser<Email> CreateParser(Email mail)
    {
        return new EmailPaqrser<Email>();
    }
    
    static void Main(string[] args)
    {
        dynamic t = new Url();
        var parser = CreateParser(t); // invokes CreateParser(Url uri)
    
        t = new Email();
        parser = CreateParser(t);  // invokes CreateParser(Email email)
    }
