    Process process = Process.Start(text, "-strip all " + path);
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = false;
    process.Start();
    while (!process.StandardOutput.EndOfStream)
    {
         string value = process.StandardOutput.ReadLine();
         stringBuilder.AppendLine(value);
    }
    process.WaitForExit();  // <-------- WAIT HERE
