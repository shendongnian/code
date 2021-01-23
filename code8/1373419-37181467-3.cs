    bool equal = true;
    var allKeys = cont1.Keys.Concat(cont2.Keys).ToList();
    var containerChecker = new ContainerCheck();
    foreach (string key in allKeys)
    {
        Container c1;
        Container c2;
        if (!cont1.TryGetValue(key, out c1) || !cont2.TryGetValue(key, out c2))
        {
            equal = false;
        }
        else
        {
            // deep check both containers
            if (!containerChecker.Equals(c1, c2))
                equal = false;
        }
        if(!equal)
            break;  // or collect differences
    }
