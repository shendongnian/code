    string[] file1Content = System.IO.File.ReadAllLines("file1.txt");
    string[] file2Content = System.IO.File.ReadAllLines("file2.txt");
    string[] file3Content = System.IO.File.ReadAllLines("file3.txt");
    var file2Missings = file2Content.Except(file1Content);
    var file3Missings = file3Content.Except(file1Content);
    string[] MasterFileContent = file2Missings.Concat(file3Missings).Distinct().ToArray();
    foreach(string s in MasterFileContent.Distinct().ToArray())
          Console.WriteLine(s + " must be placed in file 1"); 
