    public void AddToCluster(int id, ClusterMember member)
    {
        // checks if cluster with specific id is already in Dictionary
        if(!_dic.ContainsKey(id))
           _dic.Add(id,new List<ClusterMember>());
         _dic[id].Value.Add(member);
    }
