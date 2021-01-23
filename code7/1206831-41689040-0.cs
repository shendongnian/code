    [HttpPost]
    public JsonResult SubmitForms(Note note, string action = "Submit") 
    {
         SaveDemographicForm(new DemographicForm { /*your properties*/ }, "Save", false);
         
         //somecode
         //submitforms return
    }
    
    [HttpPost]
    public JsonResult SaveDemographicForm(DemographicForm demographicForm, string action = "Save", bool submitAll = false )
    {
          //return some json object
    }
