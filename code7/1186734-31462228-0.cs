    WebClient web = new WebClient();
    System.IO.Stream stream = web.OpenRead("http://example.com/subdom/prg/text.txt");
    using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
    {
        while (!reader.EndOfStream) 
        {
            string text = reader.ReadLine();
			Console.WriteLine(text);
        }
    }
