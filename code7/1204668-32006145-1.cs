    for(i = 0; i < idlist.Count(); i++)
    { 
         fiyatList.Add(db.Urunlers.Where(a => a.UrunId == int.Parse(idlist[i])
                         .FirstOrDefault()).ToString()); 
    }
