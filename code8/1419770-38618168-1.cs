	public override string ToString()
    {
        string content = "";
        foreach (var prop in this.GetType().GetProperties())
        {
			var propertyType = prop.PropertyType;
			var propertyValue = prop.GetValue(this);
            if (propertyValue is IEnumerable<string>)
                content += prop.Name + " = " + PrintList(propertyValue as IEnumerable<string>);
            else
            content += prop.Name + " = " + propertyValue.ToString() + "\r\n";
        }
        content += "\r\n";
        return content;
    }
    private string PrintList(IEnurable<string> list)
    {
        string content = "[";
        int i = 0;
        foreach (string element in list)
        {
            content += element;
            if (i == list.Count)
                content += "]";
            else
                content += ", ";
        }
        return content;
    }
