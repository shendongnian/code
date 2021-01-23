    public ActionResult GetData()
    {
        dynamic point = Request.Form;
        string x = point.x; // == val1
        string y = point.y; // == val2 
    }
