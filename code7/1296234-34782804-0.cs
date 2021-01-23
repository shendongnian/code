    var sb = new StringBuilder();
    bool spaceFound = false;
    foreach(var c in str)
    {
        if(c == ' ')
        {
            if (spaceFound) 
                break;
            spaceFound = true;
        }
        else
        {
            if (!spaceFound)
                continue;
            sb.Append(c);
        }
    }
    var secondWord = sb.ToString();
