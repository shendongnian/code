    static int? MaxPasswordAge()
    {
        var tempFile = Path.GetTempFileName();
        var si = new StartInfo {
            FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\secedit.exe"),
            Arguments = String.Format(@"/export /cfg ""{0}"" /quiet", tempFile),
            CreateNoWindow = true,
            UseShellExecute = false
        };
        var p = new Process(si);
        p.Start();
        p.WaitForExit();
        var file = IniFile.Load(tempFile);
        IniSection systemAccess = null;
        var maxPasswordAgeString = "";
        var maxPasswordAge = 0;
        if (file.Sections.TryGetValue("System Access", out systemAccess)
            && systemAccess.TryGetValue("MaximumPasswordAge", out maxPasswordAgeString)
            && Int32.TryParse(maxPasswordAgeString, out maxPasswordAge)) { return maxPasswordAge; }
        return null;
    }
