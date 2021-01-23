    public ActionResult ViewAllThreads(string MsgPanelId)
    {
        var getUser = rentdb.OwnerRegs.Where(a => a.username == User.Identity.Name)
                                      .FirstOrDefault();
        var vm=new InboxViewModel();
        vm.Threads = rentdb.Threads.Where(a => a.owner_id == getUser.serial)
                    .Select(t=>new ThreadViewModel { Id=t.Id,Title=t.Title}).ToList();
        
         return View(vm);
    }
