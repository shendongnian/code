    string[] file1Content = System.IO.File.ReadAllLines("file1.txt");
    string[] file2Content = System.IO.File.ReadAllLines("file2.txt");
    string[] file3Content = System.IO.File.ReadAllLines("file3.txt");
    string[] MasterFileContent = file1Content.Concat(file2Content.Concat(file3Content).ToArray()).ToArray();
    
    System.IO.File.WriteAllLines(MasterFilePath, MasterFileContent.Distinct().ToArray());
