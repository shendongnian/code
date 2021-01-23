    [HttpPost]
    public ActionResult SignUp(string tcNo, string nameSurname, string eMail, 
               string number,string secretQuestionAnswer, string password, 
                                             string passwordVerify, string stateValue)
    {
    
        return Json(new {status = "success"});
    }
