     string[] allLines = File.ReadAllLines(@"d:\test.txt");
     using (StreamWriter sw = new StreamWriter(@"d:\test.txt"))
     {
          foreach (string line in allLines)
          {
               string[] words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
               string joined = String.Join(";", words);
               sw.WriteLine(joined);
          }
     }
