    public ActionResult EditCustomerRequest(int id, string name, string date)
    {
        CustomerFoodModel CRequest =  Helper.getCustomerDetails(id);
        CustomerHistoryModel CHModel = Helper. getCustomerHistoryDetails(id);
        return PartialView("EditCustomerRequest",new CustomerFoodModel(){
             CustomerFood = CRequest,
             CustomerHistory = CHModel
        });
    
    }
