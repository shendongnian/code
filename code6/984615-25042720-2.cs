    var oQuestionWord = context.Questions.FirstOrDefault(q => q.Word == oQuestion.Word);
    if (oQuestionWord != null && oQuestionWord.Word == null)
    {
        context.Questions.InsertOnSubmit(oQuestion);
        context.SubmitChanges();
    }
