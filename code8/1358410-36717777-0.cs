    public void Traverse(List<FilterConditionDto> models)
    {
        foreach(var item in models)
        {
          if(item.nodes.Count > 0)
          {
              Traverse(item.nodes)
          }
        }
    }
