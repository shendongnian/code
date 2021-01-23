        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentViewModel paymentViewModel)
        {
            if (ModelState.IsValid)
            {
                // Some validation on credit card before sabe payment...
                // Save payment
                payment = new Payment();
                payment.EmailAddress = paymentViewModel.EmailAddress;
                payment.ConfirmEmailAddress = paymentViewModel.ConfirmEmailAddress;
                payment.Address = paymentViewModel.Address;
                payment.City = paymentViewModel.City;
                payment.Country = paymentViewModel.Country
                payment.PostCode = paymentViewModel.PostCode;
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Details", "Payments", new { id = payment.ID });
            }
    
            return View(paymentViewModel);
        }
