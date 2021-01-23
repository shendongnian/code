    var paths = new List<string>();
    for (int count = 11; count <= rowCount; count++){
        string temp = (string)(xlRange.Cells[count, 2] as Excel.Range).Value2; 
        string[] filePaths = Directory.GetFiles(@"\\fileshare01\Data\subfolder1\subfolder2\", temp, SearchOption.AllDirectories);
        if ((filePaths == null) || (filePaths.Length == 0))
        {
          Console.WriteLine("Didn't find file: " + temp);
          continue; // Or break, or exit, or...
        }
        string filePath = filePaths[0];
        // If the temp is a single filename (no globs), you don't even need the next two lines
        string justPath = Path.GetDirectoryName(filePath);     
        string sourceFile = System.IO.Path.Combine(justPath, temp);                
        string destFile = System.IO.Path.Combine(targetPath, temp);
        Console.WriteLine("File Path " + z+ " of "+ actualRows +" : "+ filePath + "\n");
        System.IO.File.Copy(sourceFile, destFile, true);
        paths.Add(sourceFile); // or destFile, or what you want to store
        z++;
    }
