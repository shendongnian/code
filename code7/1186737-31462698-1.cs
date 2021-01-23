    using (var web = new WebClient())
    using (var stream = web.OpenRead("http://example.com/subdom/prg/text.txt"))  
    using (var reader = new System.IO.StreamReader(stream))
    {
        string line = null;
        while ( (line = reader.ReadLine()) != null) 
        {
            SendLogin(line, "password", "1");
        }
    }
