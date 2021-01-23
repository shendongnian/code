    public void Main()
    {
        string fullPath = Path.Combine(Dts.Variables["User::FilePath"].Value.ToString(), Dts.Variables["User::FileFound"].Value.ToString(), Dts.Variables["User::FileExtension"].Value.ToString());
        var fileInfo = new FileInfo(fullPath);
        if (fileInfo.Exists())
        {
            Dts.Variables["FileFoundSize"] = fileInfo.Length;
            Dts.TaskResult = (int)ScriptResults.Success;
        }
        else
        {
            // file could not be found     
            Dts.TaskResult = (int)ScriptResults.Failure;
        }
