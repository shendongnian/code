        WebClient wc = new WebClient();
        System.IO.Stream stream = wc.OpenRead(strFilePath);
        StreamReader sReader = new StreamReader(stream);
        string strTables = sReader.ReadToEnd();
        if (!string.IsNullOrEmpty(strTables))
        { 
            // I'm not a regex master but I'm sure there is a way to get the title without the <p> elements.
            var pMatches = Regex.Matches(strTables, "<p>.*</p>"));
            foreach(var pMatch in pMatches)
            {
               string title = pMatch.Replace('<p>',string.Empty).Replace('</p>', string.Empty);
            }
        }
