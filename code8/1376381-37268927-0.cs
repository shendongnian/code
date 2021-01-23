    private Dictionary<Type, int> serializationTable = new Dictionary<Type, int>();
    
    public int GetSerializationIndex(Type type)
    {
        int index;
    
        if (!this.serializationTable.TryGetValue(type, out index))
        {
            index = this.serializationTable.Count;
            this.serializationTable.Add(type, index);
        }
    
        return index;
    }
