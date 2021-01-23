public static void ExecuteInBash(string command)
{
    var process = new Process
    {
        StartInfo = 
        {
            FileName = "bash",
            Arguments = "-c \"" + command + "\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        }
    };
    process.Start();
}
