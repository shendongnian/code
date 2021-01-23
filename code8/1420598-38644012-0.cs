    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.OutputDataReceived += (sender, args) => 
    {
        // Add args to a TextBox, ListBox, or other UI element
    }
    process.Start();
    process.BeginOutputReadLine();
