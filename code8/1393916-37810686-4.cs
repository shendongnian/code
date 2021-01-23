    StringBuilder sbResult = new StringBuilder("<root>");
    foreach (string Line in File.ReadAllLines(@"d:\sample.txt"))
    {
        sbResult.Append(GetXML(Line.Split('/')));
    }
    sbResult.Append("</root>");
