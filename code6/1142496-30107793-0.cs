    public object this[int index]
    {
        get
        {
            if (myList.Any(a => a.Key == index)) return myList.FirstOrDefault(a => a.Key == index).Value;
            else return null;
        }
        set
        {
            myList = myList.Where(a => a.Key != index).ToList();
            myList.Add(new KeyValuePair<int, object>(index, value));
        }
    }
