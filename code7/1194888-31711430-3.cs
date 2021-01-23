    private static int AddTwoStrings(string one, string two) 
    {
        int iOne = 0;
        int iTwo = 0;
        Int32.TryParse(one, out iOne);
        Int32.TryParse(two, out iTwo);
        return (iOne + iTwo).ToString();
    }
