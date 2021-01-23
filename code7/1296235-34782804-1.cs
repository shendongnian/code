    var sb = new StringBuilder();
    bool spaceFound = false;
    foreach(var c in str)
    {
        if(c == ' ')
        {
            if (spaceFound) //this is our second space so we're done
                break;
            spaceFound = true;
        }
        else
        {
            if (!spaceFound) //we haven't found a space yet so move along
                continue;
            sb.Append(c);
        }
    }
    var secondWord = sb.ToString();
