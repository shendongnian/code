    FileStream fs = new FileStream(SourceFile, FileMode.Open);
    using (StreamReader sr = new StreamReader(fs))
    {
        string line;
        string fileName = null; 
        StreamWriter outputFile = null;
        int lineCounter = 0;
        int outputFileIndex = 0;
        
        while ((line = sr.ReadLine()) != null)
        {
            if (fileName == null || lineCounter >= 10000)
            {
                lineCounter = 0;
                outputFileIndex++;
                fileName = @"D:\Output\" + fname + "_" + outputFileIndex + ".txt";
                
                if (outputFile != null) outputFile.Dispose();
                outputFile = File.AppendText(fileName);
            }
            
            outputFile.WriteLine(line);
            lineCounter++;
        }
    }
