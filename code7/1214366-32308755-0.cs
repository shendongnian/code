    // Create a temporary file, delete if it already exists
    string MyFile = Path.GetTempPath() + v_fexpd.Dateiname;
    if (File.Exists(MyFile)) {
        File.Delete(MyFile);
    }
    using (TextWriter tw = new StreamWriter(MyFile.ToString(), true, System.Text.Encoding.GetEncoding(1252)))
        tw.WriteLine(v_Inhalt);
    context.Response.Clear();
    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + v_fexpd.Dateiname);
    context.Response.AddHeader("Content-Type", "text/csv; charset=windows-1252");
    // Write the file - which at this point is correctly-encoded - 
    // directly into the output.
    context.Response.WriteFile(MyFile);
                   
    context.Response.End();
    // Leave no traces
    File.Delete(MyFile);
