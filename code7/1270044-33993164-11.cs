    var new_list = new List<Object>()
        foreach(var item in _list){
           var temp = new {
                PrefixSA = _context.BizV.Find(item.PrefixSA).ShortDesc;
                CodeCalendar = _context.BizV.Find(item.CodeCalendar).ShortDesc;
                Product = _context.BizV.Find(item.Product).ShortDesc;
                RequestType = _context.BizV.Find(item.RequestType).ShortDesc;
            }
            new_list.Add(temp);
        }
