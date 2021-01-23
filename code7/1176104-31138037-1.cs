    var pathFOSE = @"D:\Public\temp\FOSEtest.txt";
    var contents = File.ReadAllText(pathFOSE);
    var output = Regex.Replace(contents, @"(?i)(?<=[a-z0-9])(?:\r\n|\n|\r)(?=[a-z0-9])", " ");
    var pathNewFOSE = @"D:\Public\temp\NewFOSE.txt";
    if (!System.IO.File.Exists(pathNewFOSE))
    {
        File.WriteAllText(pathNewFOSE, output);
    }
