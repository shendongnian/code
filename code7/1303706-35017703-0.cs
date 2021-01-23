    public ActionResult MyData()
    {
        var oldList = db.oldList.Select(x=>x.Name).ToList();
        var newList=new list<NewListViewModel>();
          foreach(var item in oldList)
          {
           newList.Add(new NewListViewModel{Name=item.Name});
          }
        return View(newList);
    }
