    public Order(XElement p_tableRow)
    {
        foreach (XElement field in p_TableRow.Elements("Field"))
        {
            string propName = _mapping[field.Attribute("Name").Value];
            PropertyInfo propInfo = GetType().GetProperty(propName);
            MethodInfo setterInfo = propInfo.SetMethod();
            setterInfo.Invoke(this, new object[] { field.Value });
        }
    }
