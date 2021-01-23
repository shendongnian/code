    StreamReader ImportFile = new StreamReader(@"c:\users\matthew\desktop\test.txt");
    string line;
    var filesToProcess = new List<MyFuncParameters>();
    while ((line = ImportFile.ReadLine()) != null)
    {
        doneTotal++;
        string[] info = line.Split('-');
        string username = info.Length >= 1 ? info[0] : null;
        string file = info.Length >= 2 ? info[1] : null;
        filesToProcess.Add(new MyFuncParameters {File = file, UserName = username});
    }
    foreach (var fileToProcess in filesToProcess)
    {
        myfunc(fileToProcess.UserName, fileToProcess.File);
    }
