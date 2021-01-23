      private List<int> IntToList(int _Input, int _MaxSize = 8)
      {
        int padding = 1;
        List<int> resultList = new List<int>(_MaxSize);
        while (padding < 1 << _MaxSize)
          {
            resultList.Add((_Input & padding) == padding ? 1 : 0);
            padding = padding << 1;
          }
        return resultList;            
      }
    
      private int IntsToByte(List<int> _List)
      {
        int result = 0, padding = 0;
        foreach (int i in _List)
        {
            result = result | (i << padding++);
        }
        return result;            
      }
