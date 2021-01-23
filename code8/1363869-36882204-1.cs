    public ActionResult Submit(List<emp_info> list, int terminated_id)
    {
      var clients=db.Clients.Where(c=>c.Salesperson_ID==terminated_id).ToList();
      var total=clients.Count();
    
      var newlist=list
        .Aggregate(new {ID=0,percent=0},(prev,curr)=>new {
          ID=curr.ID,percent=prev.percent+curr.percent
        });
      for(var x=0;x<total;x++)
      {
        clients[x].Salesperson_ID=newlist.Last(l=>l.percent<=x*100/total).ID;
      }
      db.SaveChanges();
      ViewBag.counting = total;
      ViewBag.percentages = list.Select(l=>l.percent).ToArray();
      ViewBag.counter = total;
      return View();
    }
