    WebClient web = new WebClient();
    System.IO.Stream stream = web.OpenRead("http://example.com/subdom/prg/text.txt");
    
    using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
    {
        string line = null;
        while ( (line = reader.ReadLine()) != null) 
        {
            SendLogin(line, "password", "1");
        }
    }
