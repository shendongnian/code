    const string Delim = "-------------------------------";
    const string SomeText = "-- VSO2 CE ";
    foreach (string filePath in Directory.GetFiles("dir")) 
    {
        var first3Lines = File.ReadLines(filePath).Take(3).ToList(); 
        if(first3Lines.First() == Delim && 
           first3Lines.Last() == Delim && 
           first3Lines[1]==SomeText)
        {
            //this file's first 3 lines matches what you want.
            //now write something somehow.
            //it wasn't super clear what you want to write or do.     
            //leave a comment if you want help with that.
            DeleteLines(filePath, 3);
        }                    
    }
    private void DeleteLines(string filePath, int numLines) {
            
        using (StreamReader reader = new StreamReader(filePath))
        using (StreamWriter writer = new StreamWriter(filePath + "-new.txt")) {
            while (numLines-- > 0) { reader.ReadLine(); }
            string line;
            while ((line = reader.ReadLine()) != null)
                writer.WriteLine(line);
        }
    }
