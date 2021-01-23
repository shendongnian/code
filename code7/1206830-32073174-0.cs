    [HttpPost]
    public JsonResult SubmitForms(Note note, string action = "Submit") 
    {
         //some code
         return SaveDemographicForm(new DemographicForm { /*your properties*/ }, "Save", false);
         //some code
    }
    
    [HttpPost]
    public JsonResult SaveDemographicForm(DemographicForm demographicForm, string action = "Save", bool submitAll = false )
    {
          //return some json object
    }
