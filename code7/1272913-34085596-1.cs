    public string BuildHtmlFromTemplate<T>(templateFilePath, T o)
    {
        var temp = File.IO.ReadAllText(templateFilePath);
        foreach(var prop in typeof(T).GetProperties()){
            temp = temp.Replace("{"+prop.Name+"}", prop.GetValue(o));
        }
        return temp;
    }
