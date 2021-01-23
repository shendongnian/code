    StringBuilder xmlBuilder = new StringBuilder();
    string letter = string.Empty;
    string title = string.Empty;
    xmlBuilder.Append("<MyHeader>");
    foreach (foo item in foos)
    {
        if (title != string.Empty && item.title != title)
        {
            xmlBuilder.Append("</columnHeader2>");
        }
        if (letter != string.Empty && item.letter != letter)
        {
            xmlBuilder.Append("</columnHeader1>");
        }
        if (item.letter != letter)
        {
            letter = item.letter;
            xmlBuilder.AppendFormat("<columnHeader1 foo='{0}' order='{1}'>", item.letter, item.order);
        }
        if (item.title != title)
        {
            title = item.title;
            xmlBuilder.AppendFormat("<columnHeader2 title=\"{0}\">", item.tile);
        }
        xmlBuilder.AppendFormat("<columnHeader3 id=\"{0}\" />", item.titleid)
    }
    xmlBuilder.Append("</columnHeader2>");
    xmlBuilder.Append("</columnHeader1>");
    xmlBuilder.Append("</MyHeader>");
