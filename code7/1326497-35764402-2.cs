    SortedList<int, int> colorHistory = new SortedList<int, int>();
    int k = -1;
    for (int i = 0; i < myList.Count; i++)
    {
        if (!colorHistory.ContainsKey(myList[i].SourceTitle))
        {
            colorHistory[myList[i].SourceTitle] = ++k % colorPallete.Length;
        }
        myList[i].Color = colorPallete[colorHistory[myList[i].SourceTitle]];
    }
