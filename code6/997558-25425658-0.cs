    var app = new Application();
    app.OpenCurrentDatabase(@"C:\Users\Public\Database1.accdb");
    for (int i = 0; i < app.CurrentProject.AllReports.Count; i++)
    {
        string rptName = app.CurrentProject.AllReports[i].Name;
        Console.WriteLine("Dumping [{0}] ...", rptName);
        string fileSpec = @"C:\__tmp\ReportDump\" + rptName + ".txt";
        app.SaveAsText(AcObjectType.acReport, rptName, fileSpec);
    }
    app.CloseCurrentDatabase();
    app.Quit();
