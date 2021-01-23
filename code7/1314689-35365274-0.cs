    using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    using (BufferedStream bs = new BufferedStream(fs))
    using (StreamReader sr = new StreamReader(bs))
    using (StreamWriter writer = new StreamWriter("C:\test\test.txt"))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string output = line;
            foreach (XmlNode node in xmlNodes)
            {
                 string pattern = node["pattern"].InnerText;
                 string replacement = node["replacement"].InnerText;                           
                 Regex rgx = new Regex(pattern);
                 output = rgx.Replace(output, replacement);
                 rgx = null;
            }
            if (output.Length > 0)
            {
                 count++;
                 if (count % 10000 == 0)
                 {
                      Console.WriteLine(count);
                      Console.WriteLine(DateTime.Now.ToString());
                 }
                 writer.WriteLine(output);
             }
        }
        writer.Close();
    }
