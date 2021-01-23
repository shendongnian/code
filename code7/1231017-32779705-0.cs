    private int ExtractNumbers(List<string> myList, int start, int end)
    {
        int count = 0;
        for (int i = start; i <= end; i++)
        {
            if (myList[i].Contains("MYNUMBER:"))
            {
                count++;
            }
        }
        return count;
    }
