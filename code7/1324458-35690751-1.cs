    public ActionResult Index()
    {
       var vm=new DonationListVm();
       var all =db.Donations.OrderByDescending(s=>s.Amount);
       if(all.Any())
       { 
         //Get the highest amount record
          var h = all.First();
          vm.Highest.Name=h.Name;
          vm.Highest.Amount = h.Amount;
          vm.Highest.Comment = h.Comment;
       }
       //Get all the records
       vm.All=all.Select(x=>new DonationVm { Amount=x.Amount, 
                                     Comment=x.Comment, DisplayName =x.DisplayName}).ToList();
       return View(vm);
    }
