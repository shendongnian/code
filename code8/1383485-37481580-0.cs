    List<ShowService.Itemss> itemlist = showklient.GetItems().ToList();    
    foreach (var item in itemlist)
    {
        item.Name = item.Name + " || Price: " + item.Price + ":-";
    }
    ViewBag.Id = new SelectList(itemlist , "Id", "Name");
