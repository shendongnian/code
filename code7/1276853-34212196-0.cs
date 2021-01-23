       IList<object> iListObj = new List<object>
       {
            1234,
           "Harold Nelson",
           false,
           'A'
       };
       var typeList = new List<object>();
       foreach (var item in iListObj)
       {
           typeList.Add(item.GetType());
       }
