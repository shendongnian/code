    public string SelectedfileType
    {
    get { return Regex.Replace(fileType.ToString(), "([a-z])([A-Z])", "$1 $2")); }
    set { fileType=enum.Parse(typeOf(FileTypeSupport),value.Replace(" ","");
    }
