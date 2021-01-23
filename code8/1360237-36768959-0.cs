    string path = @"C:\Users\Nate\Documents\Visual Studio 2015\Projects\Chapter 15\Chapter 15 Question 7\Chapter 15 Question 7\TextFile.txt";
    using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (BufferedStream bs = new BufferedStream(fs))
        {
            var sw = new System.IO.StreamWriter(bs);
            var sr = new System.IO.StreamReader(bs);
            
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                 line = line.Replace("start", "finish");
                 // but you are appending a new line at the end and not replacing the exact occurrence of the word. But that is an other question.
            }
       }
