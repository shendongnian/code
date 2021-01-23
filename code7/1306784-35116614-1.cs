    var libPath = System.IO.Path.GetDirectoryName(
        new Uri(
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase
        ).LocalPath
    );
    var filePath = System.IO.Path.Combine(
        libPath,
        "AFolder",
        "textFileName.txt");
    var fileContent = System.IO.File.ReadAllText(filePath);
