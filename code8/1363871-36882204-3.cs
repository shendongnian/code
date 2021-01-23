    public ActionResult Submit(List<emp_info> list, int terminated_id)
    {
      // Grab records to update in one call
      var clients=db.Clients.Where(c=>c.Salesperson_ID==terminated_id).ToList();
      var total=clients.Count();
    
      if (clients.Sum(c=>c.percent)!=100)
        throw new ApplicationException("Percentages must add up to 100%!");
      // Create new array with upperbound percent
      var newlist=list
        .Aggregate(new {ID=0,percent=0},(prev,curr)=>new {
          ID=curr.ID,percent=prev.percent+curr.percent
        });
      // Sanity check
      Debug.Assert(newlist.Last().percent==100);
      // Loop through records and assign new salesperson
      for(var x=0;x<total;x++)
      {
        clients[x].Salesperson_ID=newlist.Last(l=>l.percent<=x*100/total).ID;
      }
      // Send updates to database
      db.SaveChanges();
      ViewBag.counting = total;
      ViewBag.percentages = list.Select(l=>l.percent).ToArray();
      ViewBag.counter = total;
      return View();
    }
