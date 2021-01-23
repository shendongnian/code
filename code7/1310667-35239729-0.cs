    if (Randomize)
    {
        List<tblInvoice> _Result = new List<tblInvoice>();
        var _Temp = xxx.Where(p => (p.isPostalPayment == null || p.isPostalPayment == false)).ToList();
        List<long> _UserIDs = new List<long>();
        foreach (var _Row in _Temp.OrderBy(o => Guid.NewGuid()).ToList())
        {
            if (_Result.Count == 3)
                break;
    
            if (!_UserIDs.Contains(_Row.ID))
            {
                _UserIDs.Add(_Row.cUserID);
                _Result.Add(_Row);
            }
        }
        return _Result;
    }
