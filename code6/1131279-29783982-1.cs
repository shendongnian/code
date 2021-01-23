    public ActionResult AnswerQuestion(QAndAViewModel vm)
    {
        //update answer cache here
        //get next question by adding 1 to the question count in the view model
        return View(new QAndAViewModel { Question = "How are you?", QuestionCount = vm.QuestionCount + 1 });
    }
