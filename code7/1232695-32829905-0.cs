    public void RestoreState() 
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
                //reference = PropertyCopy<PrestationInfo>.CopyFrom(mementoObject as PrestationInfo);   //Property copy
                //Interlocked.Exchange(ref reference, mementoObject);   //Also tried this
            }
        }
    }
