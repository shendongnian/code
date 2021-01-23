    List<List<string>> list = new List<List<string>>();
    foreach (var item in db.Pos)
    {
    	List<string> listItem = new List<string>();
    	var total = 0;
    	decimal costo = 0;
	    for (int i = 1; i <= 31; i++)
	    {
		    var value = 0;
		    if (item.Fecha.Day == i) { value = item.Cantidad; costo = costo + item.Total; }
		    total += value;
	    }
	    listItem.Add(item.Descripcion);
	    listItem.Add(item.Pdv);
	    listItem.Add(item.Rid);
	    listItem.Add(((costo / (total + 1)).ToString("C")));
	    for (int i = 1; i <= 31; i++)
	    {
		    var value = 0;
		    listItem.Add(value.ToString());
		    int month = item.Fecha.Month;
		    if (item.Fecha.Day == i) { value = item.Cantidad;    listItem.Add(value.ToString()); }                                                
	    }
	    listItem.Add(total.ToString());
	    listItem.Add((((costo / (total + 1)) * total).ToString("C")));
	    list.Add(listItem);
    }
    var json = JsonConvert.SerializeObject(list);
    System.IO.File.WriteAllText(@"\path.txt", json);
