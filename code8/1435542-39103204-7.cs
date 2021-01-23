    public void AddToMyDictionary(string value)
    {
        int NextKey = MyDictionary.Keys.Max() + 1;
        MyDictionary.Add(NextKey, value);
    }
