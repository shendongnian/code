    var txtFiles = Directory.GetFiles(@"E:\PROJ\replaceY\replaceY\", "*.txt");
            foreach (string currentFile in txtFiles)
            {
            using (StreamReader sr = new StreamReader(currentFile))
                {
                     string input = sr.ReadToEnd();
                     string pattern = "(?<=^.{4,4}).";
                     string replacement = "h";
                     Regex rgx = new Regex(pattern, RegexOptions.Multiline);
                     string result = rgx.Replace(input, replacement);
                     using (StreamWriter outfile = new StreamWriter(currentFile, append))
                      {
                          outfile.Write(result);
                      }
                }
    }
