    using MyProject.Helper;
    
    public ActionResult MyAction(){
        ...
        // your other code
        Helper helperObj = new Helper();
        bool isValid = helperObj.Validate(v1, v2);
    
        ...
    }
