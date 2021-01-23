    var Original = new int[TempArray.Length];
    var originalCounter = 0;
    
    for (int i = 0; i < TempArray.Length; i++)
    {
        if (TempArray[i] != -1)
        {
            Original[originalCounter++] = TempArray[i];
        }
    }
