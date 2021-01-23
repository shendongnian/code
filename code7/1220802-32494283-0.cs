    List<string> ocl = BuildOutCsvLine(line);
    var oclFinal = "";
    ocl.ForEach(o => {
        System.Console.WriteLine(o);
        oclFinal = string.Join(",", oclFinal, o);
    });
