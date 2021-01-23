    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Offer([Bind(Include = "AdID,Title,Text,Price,Offer,Location,PaymentOptions,DeliveryOptions,SellerEmail")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToRoute("ilmoitus", new { id = ad.AdID });
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            }
            
        }
