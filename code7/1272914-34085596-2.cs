    public string BuildHtmlFromTemplate(templateFilePath, object o)
    {
        var temp = File.IO.ReadAllText(templateFilePath);
        foreach(var prop in o.GetType().GetProperties()){
            temp = temp.Replace("{"+prop.Name+"}", prop.GetValue(o));
        }
        return temp;
    }
