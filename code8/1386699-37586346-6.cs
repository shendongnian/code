        public JsonResult GetVisitCustomer(string term)
        {
            var objCustomerlist = db.Customers.Where(c => c.IsDeleted == false)
                            .Where(c => c.CustomerName.ToUpper()
                            .Contains(term.ToUpper()))
                            .Select(c => new { Name = c.CustomerName, ID = c.CustomerID })
                            .Distinct().ToList();
            return Json(objCustomerlist, JsonRequestBehavior.AllowGet);
        }
