     string[] allLines = File.ReadAllLines(@"d:\test.txt");
     using (StreamWriter sw = new StreamWriter(@"d:\test.txt"))
     {
          foreach (string line in allLines)
          {
               string[] words = line.Split(' ');
               for (int i = 0; i < words.Count(); i++)
               {
                    words[i] = words[i].Trim();
               }
               string joined = String.Join(";", words);
               sw.WriteLine(joined);
          }
     }
