    private static void WriteXMLFile(string fileName)
    {
        using (StreamWriter sw = new StreamWriter(...))
            WriteXML(sw);
    }
    private static string GetXML()
    {
        using (StringWriter sw = new StringWriter())
        {
            WriteXML(sw);
            return sw.ToString();
        }
    }
