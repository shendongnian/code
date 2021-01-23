    NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary(); 
    
    oDict.DictionaryFile = "en-US.dic"; 
    oDict.Initialize();
    string wordToCheck = "door";
    NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling(); 
    
    oSpell.Dictionary = oDict; 
    if(!oSpell.TestWord(wordToCheck))
    {
        //Word does not exist in dictionary
        ...
    }
