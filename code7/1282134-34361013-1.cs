    if (args.Length > 0 && (File.Exists(args[0]) || Directory.Exists(args[0])))
    {
        string path;
        path = args[0];
        Console.WriteLine(path);
        Clipboard.Clear();
        Clipboard.SetText(path);
        MessageBox.Show("Path copied to clipboard", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
