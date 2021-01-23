    public JsonResult GetDetail<TModel>(int id)
        where TModel : *constraint* //interface or base class that defines .Find(int)
    {       
        var result = Activator.CreateInstance<TModel>().Find(id);
    
        return Json(new
            {
                data = result
            },
            JsonRequestBehavior.AllowGet);
    }
