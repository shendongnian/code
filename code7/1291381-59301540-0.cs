    StringWriter sw = null;
    try
    {
        sw = new StringWriter();
        using (var xw = new XmlTextWriter(sw))
        {
            sw = null; //need to set null
            doc.WriteTo(xw);
            return sw.ToString();
        }
    }
    finally
    {
        sw?.Dispose();
    }
