    var uniqueItems = item.Requeridos.Union(item.Informados).Union(item.Opcionais);
    if(item.Requeridos.Count()+item.Informados.Count()+item.Opcionais.Count()>uniqueItems.Count())
    {
        // throw your error.
    }
