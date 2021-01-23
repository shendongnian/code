     list.Add("[");
     list.Add(item.Descripcion);
    // rest code....
    
    list.Add((((costo / (total + 1)) * total).ToString("C")));
    list.Add("]");
