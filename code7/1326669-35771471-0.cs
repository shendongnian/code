    [HttpPost]
    public JsonResult MethodName(ViewModel model)
    {
    // Your Code here       
    }
    public class ViewModel 
    {   
    //All your property which you passing from view to controller via AJAX  
    public string id { get; set; }
    public string idType { get; set; }
    public string objectId { get; set; }
    public string type{ get; set; }
    }
