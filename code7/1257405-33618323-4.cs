    public static void numberGen(SortedList<string, string> alphaList)
    {
        List<string> keyList = new List<string>();
        for (int b = 0; b < 20; b++)
        {
            int max = alphaList.Count;
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();   //<-- This line is the problem
