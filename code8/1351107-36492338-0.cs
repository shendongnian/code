    void UpdateHashTable(Hashtable ht){
        foreach(var kvp in ht){
            if(userData.ContainsKey(kvp.Key)){
                userData[kvp.Key] = kvp.Value;
            }
            else{
                userData.Add(kvp.Key, kvp.Value);
            }
        }
    }
