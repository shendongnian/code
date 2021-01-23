    string html = e.Result;
           string theBody = "";
           RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
           Regex regx = new Regex("<body>(?<theBody>.*)</body>", options);
           Match match = regx.Match(html);
           if (match.Success)
           {
               theBody = match.Groups["theBody"].Value;
           }
