    var list = new List<SelectListItem>();
    var today = DateTime.Now;
    foreach (var item in db.Pos.Select(l => l.Fecha).Distinct())
    {
       var dateday = item.ToString("yyyy-MM-dd");
       var listItem = new SelectListItem { Value = dateday, Text = dateday };
       listItem.Selected = today.Day == item.Day;
       list.Add(listItem);
    }
    ViewBag.Fechas = list;
