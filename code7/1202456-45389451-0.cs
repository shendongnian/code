    private List<int> IntToList(List<int> _List, int _Input)
    {
       int _Padding = 1;
       while (_Padding < 1 << 8)
        {
            _List.Add((_Input & _Padding) == _Padding ? 1 : 0);
            _Padding = _Padding << 1;
        }
        return _List;           
    }
    private int IntsToByte(List<int> _List, int l)
    {
        int _Result = 0, _Padding = 0;
        for (int i = l; i < (l + 8); i++)
        {
            _Result = _Result | (_List[i] << _Padding++);
        }
        return _Result;
    }
