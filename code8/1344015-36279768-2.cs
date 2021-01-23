    public void AddInCluster(int id, List<ClusterMember> _clusMem)
    {
        if (_dic.ContainsKey(id))
        {
            foreach (var clusterMember in _clusMem)
            {
                _dic[id].Add(clusterMember);                    
            }
        }
        else
        {
            _dic.Add(id, _clusMem);
        }
    }
