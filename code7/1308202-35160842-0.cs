    var list = new List<Dictionary<string, object>>();
    
    foreach (var item in db.Pos)
    {
         var dic = new Dictionary<string, object>();
         dic.Add("Description", item.Descripcion);
         dic.Add("Pdv", item.Pdv);
         dic.Add("Rid", item.Rid);
         dic.Add("Total", total);       
         
         list.Add(dic);
    }
