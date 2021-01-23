    string path = @"c:\Your\Path\to\the\file";
    string file = "check.docx";
    // make copy
    string tmp = Path.GetTempFileName().Replace(".tmp", Path.GetExtension(file));
    File.Copy(Path.Combine(path,file), tmp );
    // make it Read-Only
    File.SetAttributes(tmp, FileAttributes.ReadOnly);
    // Open the copy
    Process wordProcess = System.Diagnostics.Process.Start(tmp );
    wordProcess.EnableRaisingEvents = true;
    // remove the file as soon as  the process ends
    wordProcess.Exited += (o, args) =>
        {
            File.SetAttributes(tmp, FileAttributes.Normal);
            File.Delete(tmp);
        };
