    Process process = new Process();
    process.StartInfo.FileName = "cmd.exe";
    process.StartInfo.Arguments = "/c nslookup -type=mx gmail.com"; // Note the /c command (*)
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.Start();
    string mx = "";
    string delimiter = "mail exchanger = ";
    string outputLine;
    while ((outputLine = process.StandardOutput.ReadLine()) != null)
    {
        if (outputLine.Contains(delimiter))
            mx = outputLine.Substring(outputLine.IndexOf(delimiter) + delimiter.Length);
    }
    if (string.IsNullOrEmpty(mx))
        Console.WriteLine("Lookup failed");
    else
        Console.Write(mx);
