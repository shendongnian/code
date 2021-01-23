    List<int> list = new List<int>() { 1, 2, 3, 4, 6, 8, 9, 10, 11, 12 };
    
    int GetUniqueRandom(bool RemoveFromTheList)
    {
        if (list.Count == 0)
        {
            return -1;//nothing in the list so return negative value
        }
        //generate random index from list
        int randIndex = Random.Range(0, list.Count - 1);
        int value = list[rand];
        if(RemoveFromTheList)
        {
            list.RemoveAt(randIndex);
        }
        return value;
    }
