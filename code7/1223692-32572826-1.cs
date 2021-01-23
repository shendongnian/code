    for (int i = 0; i < lastRow - 1; i++)
    {
        string key = null;
        settingsSheet.Range["B" + (i + 2)].Value.Copy(key); 
        string value = null;
        settingsSheet.Range["A" + (i + 2)].Value.Copy(value); 
        DictionaryLoad.DIC.Add(key, value);
    }
