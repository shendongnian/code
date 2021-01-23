    // Just for simplicity.. in the real world you'd maybe use a property!
    Dictionary<string, string> TablenamesDict = new Dictionary(string, string>();
    
    // In your consturctor: Initialize dictionary
    TablenamesDict.add('AC','V2_AC');
    TablenamesDict.add('DG','V2_DG');
    TablenamesDict.add('somekey','somevalue');
    ...
    // You can use the dictionary like this:
    string keyName = Getname();
    string tableName = TablenamesDict[keyName];
