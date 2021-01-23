    private int NextKey = 0;
    public int AddToMyDictionary(string value)
    {
        int currentKey = NextKey;
        MyDictionary.Add(currentKey, value);
        NextKey = MyDictionary.Keys.Max() + 1;
        return currentKey;
    }
    public RemoveFromMyDictionary(int key)
    {
         MyDictionary.Remove(key);
         NextKey = key;
    }
