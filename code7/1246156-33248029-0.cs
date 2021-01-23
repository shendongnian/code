    string memberId = "5532";
    string value;
    if (testDictionary.TryGetValue(memberId, out value))
    {
        string finalSelectedValue = String.Format("{0}_{1}", memberId, value);
    }
    else
    {
        // member not found
    }
