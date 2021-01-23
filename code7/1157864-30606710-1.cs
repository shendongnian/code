    public ActionResult AutocompleteCustomer(string term)
    {
        InformixRepository informixRepository = new InformixRepository();
        IList<AutocompleteCustomer> customers = informixRepository.GetMatchingCustomerIds(term);
        return Json(customers, JsonRequestBehavior.AllowGet);
    }
