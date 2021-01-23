    public ActionResult Donate(PaymentCharirtVm model)
    {
       var charity = new Charity { DisplayName =model.Amount,Comment =model.Comment};
       var payment = new Payment ();
       //set the properties of payment here
       db.Donations.Add(charity);
       db.SaveChanges();
       //now save Payment
       db.Payment.Add(payment);
       db.SaveChanges();
       return RedirectToAction("Confirmation","Payment", new { id=payment.Id });
    }
