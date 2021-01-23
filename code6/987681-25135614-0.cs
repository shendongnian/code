    var cmsque = new CMSQUE
    {
        queedfcodequestiontype = questionEdfValue.ToString(),
        quenotes = model.QuestionDescription,
        queisexternaltext = false,
        quenumofoptions = model.NoofOptions,
        queusmrefidcreatedby = Convert.ToInt32(System.Web.HttpContext.Current.Session["usmrefid"]),
        quescore = model.QuestionScore / model.NoofQuestions,
        quetime = model.QuestionDuration  
    };
    db.CMSQUEs.Add(cmsque);
    db.SaveChanges();
    db.Entry(cmsque).GetDatabaseValues();
    var identityValue = cmsque.ID;
