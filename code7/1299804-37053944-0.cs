    // hold chars with their Bidi Class Value
    var udb = new Dictionary<char, string>();
    
    // download UnicodeData txt file
    var cli = new WebClient();
    var data = cli.DownloadData("http://www.unicode.org/Public/UNIDATA/UnicodeData.txt");
    // parse
    using (var ms = new MemoryStream(data))
    {
        var sr = new StreamReader(ms, Encoding.UTF8);
        var line = sr.ReadLine();
        while (line != null)
        {
            var fields = line.Split(';');
    
            int uc = int.Parse(fields[0], NumberStyles.HexNumber);
            // above 0xffff we're lost
            if (uc > 0xffff) break;
    
            var ch = (char) uc;
            var bca = fields[4];
    
            udb.Add(ch, bca);
    
            line = sr.ReadLine();
        }
    }
    
    // test string
    var s = "123A\xfb1d\x0620";
    
    Console.WriteLine(s);
    var pos = 0;
    foreach(var c in s)
    {
    
        var bcv = udb[c]; // for a char get the Bidi Class Value
        if (bcv == "L" || bcv == "R" || bcv == "AL")
        {
            Console.WriteLine(
                "{0} - {1} : {2} [{3}]", 
                c, 
                pos, 
                CharUnicodeInfo.GetUnicodeCategory(c), 
                bcv); 
        }
        pos++;
    }
