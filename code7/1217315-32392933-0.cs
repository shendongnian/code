    private Dictionary<string, List<object>> checkedMetainfoValues;
    
    // access by meta info:
    MetaInfoValueGroupTag metaInfoGroupTag;
    var value = checkedMetaInfoValues[metaInfoGroupTag.MetaInfo]
    
    // access by string:
    string metaInfo;
    var value = checkedMetaInfoValues[metaInfo]
