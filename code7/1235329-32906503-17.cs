    public PartialViewResult DefaultValuesPartialView(int? selectedCustomerId)
    {
         Session["theCustomerId"] = selectedCustomerId.Value;
         var model = new DefaultValuesModel
         {
             CustomerIDItem = GetCustomerIds(),
             FieldIDItem = GetValues(),
             CurrentValuesItem = GetCurrentValues()
         };
         model.TriggerOnLoad = true;
         this.customerId = selectedCustomerId.Value;
         errorMessage = "PartialView is loaded!";
         model.TriggerOnLoadMessage = errorMessage;
         return PartialView("_DefaultValuesPartialView", model);
    }
