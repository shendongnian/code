    public void AddInCluster(int id, List<ClusterMember> _clusMem)
    {
        List<ClusterMember> members;
        if (_dic.TryGetValue(id, out members))
        {
            foreach (var clusterMember in _clusMem)
            {
                members.Add(clusterMember);
            }
        }
        else
        {
            _dic.Add(id, _clusMem);
        }       
    }
