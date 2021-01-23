    Dictionary<string,Dictionary<string,object[]>> mProperties = new Dictionary<string,Dictionary<string,object[]>>();
    // populate mProperties...
    string eQuery = "";
    foreach(string sFieldQuery in mProperties.Keys)
    {
        for(int i = 0; i < mProperties[sFieldQuery]["DBAliasNames"].Length; i++)
        {
            eQuery += ", " + mProperties[sFieldQuery]["DBFields"][i] + " AS " + mProperties[sFieldQuery]["DBAliasNames"][i];
        }
    }
