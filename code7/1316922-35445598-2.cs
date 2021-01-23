    public ActionResult Index(int id)
    {
      var vm= new ClientPaymentInfo { ClientName = "Hard coded Client Name"};
      
      vm.Payments = db.PaymentsList.Where(x => x.ClientsId == id)
                    .Select(d=>new PaymentInfoVm { 
                                Id=d.Id,
                                Amount=d.Amount, 
                                PaymentNumber=d.Paymentnumber}).ToList();
      return View(vm);
      
    }
