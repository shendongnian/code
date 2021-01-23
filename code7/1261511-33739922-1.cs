    string sourceDir = @"c:\temp\";
    string targetDir = @"c:\dest\";
    List<string> listLines = new List<string>();
    string[] files = Directory.GetFiles(sourceDir);
    foreach (string file in files)
    {
        using (StreamReader sr = new StreamReader(sourceDir + Path.GetFileName(file)))
        using (StreamWriter sw = new StreamWriter(targetDir + Path.GetFileName(file)))
        {
            do
            {
                var line = sr.ReadLine();
                line = line.Replace(',', '|').Replace('\t', '|');
                sw.WriteLine(line);
            } while (!sr.EndOfStream);
        }
    }
