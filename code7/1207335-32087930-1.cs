    public ActionResult StoreProducts (StoreViewModel model)
    {
          CygnusInternalResponseViewModel response = new CygnusInternalResponseViewModel();
          response = new Logic(CApplicationId, CurrentCompanyId).GetProductsByStoreId(model.Id);
          var parentmodel = new ProductOrderViewModel() { Products = response.Model, Orders = new OrderViewModel() };
          if (response.Success)
              return View(parentmodel );
    
          return View();
    }
