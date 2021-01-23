    static int? MaxPasswordAge()
    {
        var tempFile = Path.GetTempFileName();
        var tempFile = Path.GetTempFileName();
        var p=new Process {StartInfo = new ProcessStartInfo {
            FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\secedit.exe"),
            Arguments = String.Format(@"/export /cfg ""{0}"" /quiet", tempFile),
            CreateNoWindow = true,
            UseShellExecute = false
        }};
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
