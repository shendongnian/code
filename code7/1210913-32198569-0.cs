    public void AddToCollection(double value)
    {   
        lock(syncObject)
        {
            myList.Add(value);
        }    
    }
    public int Count
    {
       lock (syncObject)
       {
          myList.Count;
       }
    }
