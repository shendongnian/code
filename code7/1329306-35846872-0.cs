    private ParameterNodeEntity _searchNodeResult;
    
    public void SearchByPath(ParameterNodeEntity nodeEntity, string path)
    {
        bool found = false;
        if (nodeEntity.Path != path)
        {
            foreach (ParameterNodeEntity subNode in nodeEntity.Nodes)
            {
                if (!found)
                {
                    SearchByPath(subNode, path);
                }
            }
        }
        else
        {
            _searchNodeResult = nodeEntity;
            found = true;
        }
    }
