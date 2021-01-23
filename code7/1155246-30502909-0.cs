    var titl = new[] {"aaa", "bbb", "ccc"};
    int i = 0;
    foreach (string item in titl)
    {
        //new instance of Data
        i = i + 1;
        if (i % 2 == 0)
        {
            writer.WriteStartElement("tTime");
        }
        else
        {
            writer.WriteStartElement("tText");
        }
        writer.WriteString(item);
        writer.WriteEndElement();
    }
