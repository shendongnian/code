    public static List<Cluster> DP_Cluster(List<string> customers, double alpha)
    {
        double probOld = 0.0;
        double probNew = 0.0;
        var clusters = new List<Cluster>();
        Cluster currentCluster = null;
        for (int i = 0; i < customers.Count; i++) {
            if (i <= clusters.Count) {
                probOld = clusters[i].Dic.Count / (i + alpha);
            } else {
                probNew = alpha / (i + alpha);
            }
            if (probNew > probOld || currentCluster == null) {
                currentCluster = new Cluster();
                clusters.Add(currentCluster);
            }
            currentCluster.Add(_memberNumber, new ClusterMember { Name = customers[i] });
        }
        return clusters;
    }
