    public long Add(object pItem)
    {
        bool firstTime;
        long id = ObjectIDGenerator.GetId(pItem, out firstTime);
        if (firstTime)
        {
            var mementoObject = DeepCopy(pItem);
            MementoList.Add(id, mementoObject);
            ReferenceList.Add(pItem);
        }
        return id;  // i need my memento! LOL
    }
    
