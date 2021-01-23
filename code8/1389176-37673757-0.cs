            List<CurrentCluster> _curClusters = new List<CurrentCluster>();
            _curClusters.RemoveAll(i => i.Value == 0);
            //OR
            for (int i = 0; i < _curClusters.Count; i++)
            {
                //If you have some more logical checking with CurrentCluster
                //before remove
                if (_curClusters[i].Value == 0)
                {
                    _curClusters.Remove(_curClusters[i]);
                    continue;
                }
            }
