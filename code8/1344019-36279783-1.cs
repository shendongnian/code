    if(needToAddNewCluster){
        _dic.Add(index, new List<ClusterMember>());
    }
    if(needToExtendCluster){
        _dic[index].Add(clusMem);
    }
