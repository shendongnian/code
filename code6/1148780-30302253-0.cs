    var filename = "...";
    var xmlText = new StringBuilder();
    bool isXml = false;
    foreach (var line in System.IO.File.ReadLines(filename))
    {
        if (line.Trim().StartsWith("<Message"))
            isXml = true;
        if (isXml)
        {
            xmlText.Append(line);
            if (line.Trim().EndsWith("</Message>"))
            {
                var xdoc = XDocument.Parse(xmlText.ToString());
                //process xml here
                xmlText.Clear();
                isXml = false;
            }
        }
    }
