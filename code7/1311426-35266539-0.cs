    	[HttpPost]
    public ActionResult EditOffer(tbl_offer modal, string Add, string Edit)
    {
        if (ModelState.IsValid)
        {
            using (joyryde_storeEntities context = new joyryde_storeEntities())
            {
                var offerID = Convert.ToInt64(Request.RequestContext.RouteData.Values["id"]);
                if (!isOfferExist(modal.DAT_START_OFFER.Value.Date, modal.DAT_END_OFFER.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999), Convert.ToInt64(Session["StoreID"]), offerID, Add, Edit, context))
                {
                    // My Code 
                    return RedirectToAction("AllOffers", "Store");
                }
                else
                {
                    ModelState.AddModelError("DAT_START_OFFER", "Date Not Available"); // Here i am adding Modal Error For Date
                    if (Edit != null)
                    {
                        return View(modal);
                    }
                    else
                    {
                        return RedirectToAction("AddOffer");
                    }
                }
            }
        }
        else
        {
			ViewBag.OfferID = Here give the office id;
            ViewBag.Header = "Edit " + objOffer.TXT_OFFER_TITLE;
            ViewBag.ActionToPerform = "Edit";
			ModelState.AddModelError("","Your Error Message"); // Here i am adding Modal Error For Date
            return View(modal);
        }
	}
