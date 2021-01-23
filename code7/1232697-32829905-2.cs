    public object RestoreState() 
    {
        for (int i = 0; i < ReferenceList.Count; i++)
        {
            object reference = ReferenceList[i];
            bool firstTime;
            long id = ObjectIDGenerator.GetId(reference, out firstTime);
            if (MementoList.ContainsKey(id))
            {
                object mementoObject = MementoList[id];
                reference = mementoObject;
                
                return reference;
            }
        }
        return null;
    }
