    var path = @"C:\SystemSetup\Runner.bat";
    var text = System.IO.File.ReadAllText(path);
    text = text.Replace("BVTTests.orderedtest", "SmokeTests.orderedtest");
    text = text.Replace("Functional_Tests_1", "Functional_Tests_3");
    System.IO.File.WriteAllText(path, text);
