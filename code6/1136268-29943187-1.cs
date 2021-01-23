    object[] names = new object[] { “Val1", “Val2", “Val3", “Val4" };
    object[] vals = new object[] { 11, 12, 13, 14 };
    object[,] namesAndVals = new object[4,2];
    for (int i = 0; i < names.Count(); i++)
    {
         namesAndVals[i, 0] = names[i];
         namesAndVals[i, 1] = vals[i];
    }
