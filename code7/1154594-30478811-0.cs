    string doc = "<id>{1}</id> <Name>{2}</Name> <Detail>{3}</Detail>";
    Dictionary<string, string> sDict = new Dictionary<string, string>();
    sDict.Add("{1}", "123456");
    sDict.Add("{2}", "Hummer");
    sDict.Add("{3}", "foo");
    foreach (var item in sDict)
    {
        doc = doc.Replace(item.Key, item.Value);
    }
