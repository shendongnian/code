    var sarasa = new JsonResult { Data = lista.Select(item=> new 
    {
        Field1 = item.Field1,
        Field2 = item.Field2,
        ...
        Fieldn = item.Fieldn
    
    }), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return sarasa;
