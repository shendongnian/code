    public IEnumerable<String> BaseNodeListFlattened
    {
      get
      {
        foreach (var baseNode in BaseNodes)
        {
          foreach (ushort matId in baseNode.MatIDBitArrayDictionary.Keys)
          {
            yield return String.Format("{0} - {1}", baseNode.Name, matId);
          }
        }
      }
    }
