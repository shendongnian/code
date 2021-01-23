    // Create the template as a temporary file
    string pathTemplate = Path.GetTempFileName();
    Assembly assembly = Assembly.GetExecutingAssembly();
    using (Stream input = assembly.GetManifestResourceStream("Vol_Report.Vol Report Template.xlsm"))
    using (Stream output = File.Create(pathTemplate))
    {
        input.CopyTo(output);
    }
