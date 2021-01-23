    // Probably somewhere at the beginning of the class as a private global field
    private Dictionary<string, int> _partOfSpeechDict;
    public yourClassConstructor()
    {
        _partOfSpeechDict = new Dictionar<string, int>();
        _partOfSpeechDict.Add("noun", 1);
        _partOfSpeechDict.Add("verb", 2);
        _partOfSpeechDict.Add("adjective", 3);
        _partOfSpeechDict.Add("adverb", 4);
    }
    int getPos(string partOfSpeech)
    {
        var pos = 5; // For 'other' or default in your case
        if (_partOfSpeechDict.ContainsKey(partOfSpeech)) 
        {
            pos = _partOfSpeechDict[partOfSpeech];
        }
        return pos;
    }
