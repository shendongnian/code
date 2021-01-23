    var toBeRemoved = new List<CurrentCluster>();
    foreach (var suspiciousCluster in _curCluseters)
    {
        if(suspiciousCluster.GetClusterSize() == 0)
        {
            toBeRemoved.Add(suspiciousCluster);
        }
    }
    foreach (var voidCluser in toBeRemoved)
    {
        _curCluster.Remove(voidCluster);
    }
