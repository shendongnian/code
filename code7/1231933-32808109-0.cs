    string text;
    List<string> payloadwords = new List<string>(); // notice the assigned instance of list
    StreamReader RD = new StreamReader(openfilepay.FileName);
    while ((text = RD.ReadLine()) != null)
    {
        payloadwords.Add(text);
    }
