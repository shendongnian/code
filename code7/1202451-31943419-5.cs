      private List<int> IntToList(int _Input, int _MaxSize = 8)
      {
        List<int> _List = new List<int>(_MaxSize);
        int padding = 1;
        while (padding < 1 << _MaxSize)
          {
            _List.Add((_Input & padding) == padding ? 1 : 0);
            padding = padding << 1;
          }
        return _List;            
      }
    
      private int IntsToByte(List<int> _List)
      {
        int _result = 0;
        int padding = 0;
        foreach (int i in _List)
        {
            _result = _result | (i << padding++);
        }
        return _result;            
      }
