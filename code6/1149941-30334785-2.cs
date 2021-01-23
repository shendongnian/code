    [HttpPost]
    public ActionResult QuestionOneNext(SurveyViewModelNew surveyViewModel, string direction)
    {
        var currentSurveyViewModel = surveyViewModel ?? (SurveyViewModel)TempData["SurveyView"];
        if (direction == "Countinue to submit this survey")
        {
            TempData["SurveyView"] = currentSurveyViewModel;
            return RedirectToAction("Edit", "something", null);
        }
    
        if (direction == "Add a New Question to this survey")
    
        {
            return View("QuestionTwo", currentSurveyViewModel);
            //return RedirectToAction("QuestionTwo", "CreateSurveyStep2", surveyViewModel);
        }
        if (direction == "Previous Step")
        {
            TempData["SurveyView"] = currentSurveyViewModel;
            return RedirectToAction("Index", "CreateSurveyStep1", null);
        }
    
        return View();
    }
    
    [HttpPost]
    public ActionResult QuestionTwo(SurveyViewModelNew surveyViewModel, string direction)
    {
        var currentSurveyViewModel = surveyViewModel ?? (SurveyViewModel)TempData["SurveyView"];
        if (direction == "Countinue to submit this survey")
        {
            TempData["SurveyView"] = currentSurveyViewModel ;
            return RedirectToAction("Edit", "NutStorage", null);
        }
    
        if (direction == "Add a New Question to this survey")
        {
            //return RedirectToAction("QuestionThree", "CreateSurveyStep2", surveyViewModel);
            return View("QuestionThree", "CreateSurveyStep2", currentSurveyViewModel );
        }
        if (direction == "Previous Step")
        {
            TempData["SurveyView"] = currentSurveyViewModel ;
            return RedirectToAction("QuestionOne", "CreateSurveyStep2", null);
        }
    
        return View();
    }
