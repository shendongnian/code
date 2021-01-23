    private List<int> IntToList(int _Input)
    {
        List<int> _List = new List<int>(8);
        for (int i = 0; i < 8; i = i << 1)
        {
            _List.Add(_Input & i);
        }
        return _List;            
    }
    
    private int IntsToByte(List<int> _List)
    {
        int result = 0;
        int padding = 7;
        for (int padding = 7; padding >= 0; ++padding)
        {
            _result = _result | (_List[i] << padding);
        }
        return _result;            
    }
