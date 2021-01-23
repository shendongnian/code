    foreach (RemoteFileInfo file in MySession.EnumerateRemoteFiles(directory.RemoteDirectory, directory.RemoteFiles, EnumerationOptions.None))
    {
        int lines= File.ReadAllLines(Path.Combine(directory.LocalDirectory, file.Name)).Length.ToString();
        string appending = String.Format("{0,2}.- {1,-18} RecordCount: {3}", file.Name, lines);
        BodyMessage.Append(appending);
        index++;
    }
