    bool waitingForXy = false;
    while (xmlReader.Read())
    {
        if (xmlReader.IsStartElement())
        {
            switch (xmlReader.Name)
            {
                case "B":
                    d = new Dummy();
                    waitingForXy = true;
                    break;
                case "X":
                    if (waitingForXy)
                    {
                        d.X = xmlReader.ReadString();
                    }
                    break;
                case "Y":
                    if (waitingForXy)
                    {
                        d.Y = xmlReader.ReadString();
                    }
                    break;
            }
        }
        else if (xmlReader.NodeType == XmlNodeType.EndElement)
        {
            switch (xmlReader.Name)
            {
                case "B":
                    waitingForXy = false;
                    dummyList.Add(d);
                    break;
            }
        }
    }
