    int index = 0;
    string[] collection = new string[10];
    public void Write(string text)
    {
        index %= collection.Length; // prevent overflowing
        
        collection[index++] = text;
    }
