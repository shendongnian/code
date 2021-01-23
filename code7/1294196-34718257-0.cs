    string value="Operation 2 > 3";
    string xmlValue= "<root>"+ value.Replace("<","&lt;").Replace("&", "&amp;")
                                                       .Replace(">", "&gt;")
                                                       .Replace("\"", "&quot;")
                                                       .Replace("'", "&apos;") + "</root>"
