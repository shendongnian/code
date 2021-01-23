    public List<ClusterMember> GetFromCluster(ClusterId id)
    {
        if (_dic.ContainsKey(id))
        {
            return _dic[id];
        }
        throw new ClusterDoesNotContainsThisId(id);
    }
