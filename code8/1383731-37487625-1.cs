    public Cluster(int _clusterID, int _attributeCount)
    {
      this._clusterID = _clusterID;
      this._attributeCount = _attributeCount;
      _nkA = new Int32[_attributeCount];
    
      for (var i = 0; i < _attributeCount; i++)
      {
        _attributeValues.Add(i, new UtilCS.KeyCountMap<int>());
      }
    }
