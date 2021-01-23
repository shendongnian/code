    string path = @"C:\Users\Nate\Documents\Visual Studio 2015\Projects\Chapter 15\Chapter 15 Question 7\Chapter 15 Question 7\TextFile.txt";
    string pathTmp = @"C:\Users\Nate\Documents\Visual Studio 2015\Projects\Chapter 15\Chapter 15 Question 7\Chapter 15 Question 7\TextFile-tmp.txt";
    using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (BufferedStream bs = new BufferedStream(fs))
        {
            using (StreamReader sr = new StreamReader(bs))
            {     
                string line;
                while ((line = sr.ReadLine()) != null)
                {                 
                     using (StreamWriter writer = new StreamWriter(pathTmp))
                     {
                         writer.WriteLine(line.Replace("start", "finish"));
                     }
                 }
            }
       }
    }
    File.Delete(path);
    File.Move(pathTmp, path);
