    public string GetSingleFileUrl(string file)
    {
        return String.Format("{0}/Zip/{1}.zip", this.GetBaseUrl(), file.Replace(@"\", "/"));
    }
    public string GetMultiFileUrl(string file, int part)
    {
        return String.Format("{0}/Zip/{1}.z{2:D2}", this.GetBaseUrl(), file.Replace(@"\", "/"), part);
    }
