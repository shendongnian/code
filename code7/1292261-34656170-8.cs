    foreach (string file in filesCollected)
    {
        string bc;
        string bcValue;
        ....
        if (bc == bcValue)
        {
            List<string> files = new List<string>();
            files.Add(file);
            Documents.Add(new Document(files, true, ""));
            docCount++;
        }
        else
            Documents[docCount].fullFilePath.Add(file);
    }
