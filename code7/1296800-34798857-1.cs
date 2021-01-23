    foreach (var path2 in Directory.GetFiles(path))
    {
        string[] temp = Path.GetDirectoryName(path2).Split(new string[] { "\\" }, StringSplitOptions.None);
        MyObjects.Add(new MyObject {
            CD = File.GetCreationTime(path2).ToString(),
            Link = path2,
            Folder = temp[temp.Length-1]
        });
    }
