    var path = Path.GetTempFileName();
    // Get some text we know is encoded in UTF-8 to simplify the code below
    // and contains combining codepoints as a matter of example.
    using (var web = new WebClient())
    {
        web.DownloadFile("http://superuser.com/questions/52671/which-unicode-characters-do-smilies-like-%D9%A9-%CC%AE%CC%AE%CC%83-%CC%83%DB%B6-consist-of", path); 
    }
    // since the question asks to analyze a file
    var content = File.ReadAllText(path, Encoding.UTF8); 
    var frequency = new Dictionary<String, int>();
    var itor = System.Globalization.StringInfo.GetTextElementEnumerator(content);
    while (itor.MoveNext()) 
    {
        var element = (String)itor.Current;
        if (!frequency.ContainsKey(element)) 
        {
            frequency.Add(element, 0);
        }
        frequency[element]++;
    }
    var histogram = frequency
        .OrderByDescending(f => f.Value)
        // jazz it up with the list of codepoints in each text element
        .Select(pair =>  
            {
                var bytes = Encoding.UTF32.GetBytes(pair.Key);
                var codepoints = new UInt32[bytes.Length/4];
                Buffer.BlockCopy(bytes, 0, codepoints, 0, bytes.Length);
                return new { 
                    Count = pair.Value, 
                    textElement = pair.Key, 
                    codepoints = codepoints.Select(cp => String.Format("U+{0:X4}", cp) ) };
            });
    histogram.Dump(); // For use in LINQPad
    
