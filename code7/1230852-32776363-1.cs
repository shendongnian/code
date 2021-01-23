    public static int ComputeLevenshteinDistance(string strA, string strB)
    {
        if (string.IsNullOrEmpty(strA) || string.IsNullOrEmpty(strB))
        {
            return Math.Max(strA == null ? 0 : strA.Length, strB == null ? 0 : strB.Length);
        }
        int[,] iArray = new int[strA.Length + 1, strB.Length + 1];
        for (int i = 0; i <= strA.Length; i++)
        {
            iArray[i, 0] = i;
        }
        for (int i = 0; i <= strB.Length; i++)
        {
            iArray[0, i] = i;
        }
        int iCost;
        int[] iMin = new int[3];
        for (int i = 1; i <= strA.Length; i++)
        {
            for (int j = 1; j <= strB.Length; j++)
            {
                iCost = (strA[i - 1] == strB[j - 1]) ? 0 : 1;
                iMin[0] = iArray[i - 1, j] + 1;
                iMin[1] = iArray[i, j - 1] + 1;
                iMin[2] = iArray[i - 1, j - 1] + iCost;
                iArray[i, j] = iMin.Min();
            }
        }
        return iArray[strA.Length, strB.Length];
    }
