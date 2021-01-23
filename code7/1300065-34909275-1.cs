    var Save = new List<string>();
    for (int i = 0; i < files.Count; i++)
    {
         Save.Add(nFIleUpload.OrgFileName);// display  value like testtest1test2..
    }
    var s = string.Join(",", Save);
