    public bool IsNestedUnderSubfolder(string url, string folder)
    {
        if (!url.StartsWith(folder))
            return false;
        
        return url.Substring(folder.Length).Contains("/");
    }
    // False
    IsNestedUnderSubfolder("example.com/region/site1/file.xls", "example.com/region/site1/");
    // True
    IsNestedUnderSubfolder("example.com/region/site1/folder/file.xls", "example.com/region/site1/");
