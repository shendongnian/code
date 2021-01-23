    var rez= (from p in data
              join q in webSocketData.Items on p.Code equals q.Code
              select new ItemViewModel
              { 
                ItemId = p.ItemId,
                Code = p.Code,
                Name = q.Name,
                QuantityInBase = p.QuantityInBase ,
                Price = q.Price,
                IsHidden = p.IsHidden
              }).ToList();
