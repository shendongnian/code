    public ActionResult Details(string id)
            {
                ApiModel data = new ApiModel();
                BaseViewModel model = new BaseViewModel();
                model.Order = data.GetOrderData(id);
    
                return View(model);
            }
