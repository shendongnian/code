    [HttpPost]
    public ActionResult GetDefault(int? val)
    {
        if (val != null)
        {
            //Values are hard coded for demo. you may replae with values 
           // coming from your db/service based on the passed in value ( val.Value)
            return Json(new { Success="true",Data = new { Width = 234, Height = 345}});
        }
        return Json(new { Success = "false" });
    }
