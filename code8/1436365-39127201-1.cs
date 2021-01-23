    public ActionResult SaveStuff([ModelBinder(typeof(DynamicBinder))]dynamic vm) {
    
        StoreTheValue(vm.myvalue);
    
        return Content("Saved :)");
    }
