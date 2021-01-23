    public ActionResult ManipulateCustomer(int id, int? idOrder)
            {
                CustomerModel model = new CustomerModel();
                
                model.ListAdCode = AdCodeList();
    
                if (model.ListPriceList == null)
                {
                    model.ListPriceList = CommonFunctions.PriceListActive(null);
                }
                return View(model);
            }
