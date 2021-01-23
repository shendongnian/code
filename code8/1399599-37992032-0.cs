    string currentContent = String.Empty;
    if (File.Exists(filePath))
    {
        currentContent = File.ReadAllText(filePath);
    }
    
    File.WriteAllText(filePath, header + Environment.NewLine + currentContent );
    File.AppendAllText(filepath, Environment.NewLine + footer);
