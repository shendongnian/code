    public class MaterialPaymentsViewModel {
        //other properties
        public int ParentId {get;set;}
    }
    public ActionResult CreateChild(int? parentId)
    {
        var model = new MaterialPaymentsViewModel{ParentId = parentId};
        //other stuff
        return View(model);
    }
    //View
    
    @using (Html.beginform()){
    //
    @html.hiddenfor(m => m.ParentId)
    //submit
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateChild(MaterialPaymentsViewModel  model)
    {
        if(model.ParentId != null)
    {
     //
    }
      //
    }
