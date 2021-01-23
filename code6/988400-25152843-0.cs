        int halfNumOfList = myList.Count / 2;
        int itemsRemoved = 0;
    
        for (int i = 0; i < myList.Count; i++)
        {
            if (itemsRemoved < halfNumOfList)
            {
                if (i % 2 != 0)
                {
                    myList.Remove(myList[i]);
                    itemsRemoved++;
                }
            }
        }
