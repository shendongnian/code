    //foreach (var item myList)
    for (int j = 0; j < myList.Count-1; j++)
    {
        string item1 = myList[j];
        for (int i = j + 1; i < myList.Count; i++)
        {
           string item2 = myList[i];
           // if (i == myList.Count)
           ...
        }
    }
