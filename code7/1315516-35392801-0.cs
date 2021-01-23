    public void GetDataList(string _code, int _startDate, int _limit, out List<Data> _list)
    {
        if(dateDic.ContainsKey("_code"))
        {
          return;
        }
        _list = (from data in dateDic[_code].Values     // <= System.Collections.Generic.KeyNotFoundException!!!
                where data.date >= startDate
                orderby data.date descending
                select data).Take(_limit).ToList<Data>();
    }
