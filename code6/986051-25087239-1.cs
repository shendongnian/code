    public JsonResult GetDetail(string model, int id)
    {
        Type type = Type.GetType("MyProject.WebApplication.Models.MyProjctContext." + model);            
        var result = ((dynamic)Activator.CreateInstance(type)).Find(id);
        return Json(new
        {
            data = result
        },
        JsonRequestBehavior.AllowGet);
    }
