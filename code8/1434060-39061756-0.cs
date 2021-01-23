    // Declaration outside your for loops
    List<string> ExistingLines = new List<string();
    ...
            line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
            if (line.Contains(langu[ii].InnerXml) && !ExistingLines.Contains(line))
            {
                Response.Write(line+ "</br>");
                ExistingLines.Add(line);
            }
    ....
