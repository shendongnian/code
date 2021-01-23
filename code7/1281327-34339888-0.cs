    string file = @"C:\somePath\Form1.cs";
    string output = @"C:\someOtherPath\New Text Document.txt";
    List<string> datasets = new List<string>();
    string[] lines = File.ReadAllLines(file);
    decimal i = 0;
    foreach (string line in lines)
    {
        string[] words = line.Split(' ');
                
        foreach (string word in words)
        {
            if (word.ToLower().Contains("adodataset"))
            {
                int start = word.ToLower().IndexOf("adodataset");
                string dsWord = String.Empty;
                string temp = word.Substring(start, word.Length - start);
                foreach (char c in temp)
                {
                    if (Char.IsLetter(c))
                        dsWord += c;
                    else
                        break;
                }
                if (dsWord != String.Empty)
                    datasets.Add(dsWord);
            }
        }
        i++;
        Console.Write("\r{0}%      ", Math.Round(i / lines.Count() * 100, 2));
    }
    if (datasets.Count > 0)
    {
        using (StreamWriter sw = new StreamWriter(output))
        {   
            foreach (string dataset in datasets.Distinct())
                sw.WriteLine(dataset);
        }
        Console.WriteLine(String.Format("Wrote {0} data sets to {1}", datasets.Distinct().Count(), output));
        Console.ReadKey();
    }
