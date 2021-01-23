    // Create the template as a temporary file
    string pathTemplate = Path.GetTempFileName();
    Assembly assembly = Assembly.GetExecutingAssembly();
    using (Stream input = assembly.GetManifestResourceStream("Vol_Report.Vol Report Template.xlsm")) // Note that it is Vol_Report because my namespace was Vol Report
    using (Stream output = File.Create(pathTemplate))
    {
        input.CopyTo(output);
    }
