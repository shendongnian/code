    List<List<YouObjectType>> SplitList(List<YourObjectType> listToSplit) {
        List<List<YouObjectType>> listOfLists = new List<List<YourObjectType>>();
        List<YourObjectType> tmp = new List<YourObjectType>();
        foreach(YourObjectType item in listToSplit) {
            if (tmp.Count > 0
                && tmp[tmp.Count - 1] != item) {
                // Compare you items here as you wish, 
                // I'm not sure what kind of objects
                // and what kind of comparison you are going to use
                listOfLists.Add(tmp);
                tmp = new List<YourObjectType>();
            }
            tmp.Add(item);
        }
        return listOfLists;
    }
