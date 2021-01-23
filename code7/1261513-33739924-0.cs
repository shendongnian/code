        string sourceDir = @"c:\temp\";
        string targetDir = @"c:\dest\";
        string[] files = Directory.GetFiles(sourceDir);
        foreach(string file in files)
        {
            List<string> listLines = new List<string>();
            using (StreamReader sr = new StreamReader(sourceDir + Path.GetFileName(file)))
            {
                do
                {
                    listLines.Add(sr.ReadLine());
                } while (!sr.EndOfStream);
                for (int i = 0; i < listLines.Count; i++)
                {
                    listLines[i] = listLines[i].Replace(',', '|');
                    listLines[i] = listLines[i].Replace('\t', '|');                        
                }                                         
            }
            using (StreamWriter sw = new StreamWriter(targetDir + Path.GetFileName(file)))
            {
                foreach (string line in listLines)
                {
                    sw.WriteLine(line);
                }           
            }
        }
