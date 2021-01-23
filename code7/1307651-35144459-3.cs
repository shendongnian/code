    List<data> _data = new List<data>();
    foreach (var item in Model)
    {
        var total = 0;
        decimal costo = 0;
    
        for (int i = 1; i <= 31; i++)
        {
            var value = 0;
            if (item.Fecha.Day == i) { value = item.Cantidad; costo = costo + item.Total; }
            total += value;
        }
        _data.Add(new data()
        {
            Descripcion = item.Descripcion,
            Pdv = item.Pdv,
            Rid = item.Rid,
            Costo = ((costo / (total + 1)).ToString("C")),
            Total = total,
            WhateverThisIs = (((costo / (total + 1)) * total).ToString("C"))
        });
    }
    string json = JsonConvert.SerializeObject(_data.ToArray());
    System.IO.File.AppendAllText(@"D:\path.txt", json); //make sure to use append
