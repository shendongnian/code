     using MyProj.Core.MyHelpers;  // namespace with BalanceHelper class
     public PartialViewResult _ObtemSaldo()
     {
        var userId = User.Identity.GetUserId();
        var balance = db.Balance.Where(d => 
                 d.ApplicationUserId == userId)
                      .FirstOrDefault()
                      .GetBalance();  // boom
        return PartialView(balance);
     }
