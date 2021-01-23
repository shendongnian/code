    var query = from hld in hldList
                join dic in dicID
                on hld.ID equals dic.Key
                select new HldSS 
                {
                    ID = hld.ID,
                    IDLong = dic.Value.IDLong,
                    Name = hld.Name,
                    // other properties
                };
    
    List<HldSS> res = query.ToList();
