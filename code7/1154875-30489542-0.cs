    [HttpGet]
    public ActionResult Edit(int Survey_ID)
    {
        AnswerQuestionViewModel mymodel = new AnswerQuestionViewModel();
        var myList = new List<AnswerQuestionViewModel>();
        mymodel.Survey_ID = Survey_ID;
        myList.Add(mymodel);
        return View(myList);
    }
