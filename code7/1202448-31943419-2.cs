    private List<int> IntToList(int _Input, int _MaxSize = 8)
    {
        List<int> _List = new List<int>(_MaxSize);
        for (int i = 1; i <= 1 << _MaxSize; i = i << 1)
        {
            _List.Add(_Input & i);
        }
        return _List;            
    }
    
    private int IntsToByte(List<int> _List)
    {
        int result = 0;
        int padding = _List.Count;
        foreach (int i in _List)
        {
            _result = _result | (i << padding--);
        }
        return _result;            
    }
