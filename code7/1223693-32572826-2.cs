    for (int i = 0; i < lastRow - 1; i++)
    {
        string key = string.Copy(settingsSheet.Range["B" + (i + 2)].Value); 
        string value = string.Copy(settingsSheet.Range["A" + (i + 2)].Value); 
        DictionaryLoad.DIC.Add(key, value);
    }
