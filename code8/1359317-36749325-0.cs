    [System.Web.Http.HttpGet]
    public FileResult Download()
    {
        var csv = new List<string>();
        csv.Add("Key, English, Hebrew, Russian");
        //add items as string seperated by commas to csv 
        MemoryStream mstream = new MemoryStream();
        StreamWriter sw = new StreamWriter(mstream);
        foreach (var row in csv)
        {
                sw.Write(row);
        }
        sw.Flush();
        mstream.Position = 0;
        byte[] contents = new byte[mstream.Length];
        mstream.Read(contents, 0, (int)mstream.Length);
        return File(contents, "text/csv", "DictionaryItems.csv");
    }
