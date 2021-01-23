    int a = Constants.Maxp.FirstOrDefualt(x => x.Key == SomeID).Value;
    List<SelectListItem> lst = new List<SelectListItem>();
    for (int i = 0; i < a; i++)
    {
        lst.Add(new SelectListItem(){
            Text = i.ToString(),
            Value = i.ToString()
        });
    }
    ViewBag.Pets = lst;
