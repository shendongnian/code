    public IEnumerable<string> GetCardNames()
    {
        string[] stringArray = new string[cards.Count];
        for (int i = 0; i < stringArray.Length; i++)
        {
            stringArray[i] = cards[i].ToString();
        }
        return stringArray;
    }
