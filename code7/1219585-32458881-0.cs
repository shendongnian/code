    string text2 = "AT + CMGL =\"REC UNREAD\"\r\r\n+CMGL: 5,\"REC UNREAD\",\"+420733505479\",\"\",\"2015/09/08 13:38:31+08\"\r\nPrdel\r\n\r\nOK\r\n";
    Regex regex2 = new Regex(@"CMGL: (?<num>\d+),""(?<rec>[^""]*)"",""(?<phone>[^""]*)"",""[^""]*"",""(?<date>[^""]*)""\s*(?<badword>.+)");
    Match match2 = regex2.Match(text2);
    if (match2.Success)
    {
         Console.WriteLine(match2.Groups["num"].Value);
         Console.WriteLine(match2.Groups["rec"].Value);
         Console.WriteLine(match2.Groups["phone"].Value);
         Console.WriteLine(match2.Groups["date"].Value);
         Console.WriteLine(match2.Groups["badword"].Value);
     }
