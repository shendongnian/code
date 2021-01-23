    var vm=new DonationListVm();
    vm.All=db.Donations.Select(x=>new DonationVm { Amount =x.Amount,
                   Comment =x.Comment,DisplayName=x.DisplayName }).ToList();
    //sort based on amount then take top 3 records
    vm.Highest=cm.All.OrderByDescending(y=>y.Amount).Take(3)
                 .Select(a=>new DonationVm { Amount=a.Amount,
                                             Comment=a.Comment,
                                             DisplayName=a.DisplayName}).ToList();
    return View(vm);
