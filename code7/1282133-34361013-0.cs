    if (args.Length > 0)
    {
        if (File.Exists(args[0]))
        {
            string path;
            path = args[0];
            Console.WriteLine(path);
            Clipboard.Clear();
            Clipboard.SetText(path);
            MessageBox.Show("Path copied to clipboard", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else if (Directory.Exists(args[0]))
        {
            ...
        }
    }
