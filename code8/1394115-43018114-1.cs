    protected void PageLoad(...)
    {
        AnswersPanel.InnerHtml = "";
        AnswersPanel.InnerHtml += string.Format("<input id='modelQuestions_{0}' name='modelQuestions[{0}]' type='text' placeholder='{1}' />",
                                                    i.ToString(), 
                                                  modelQuestions[i].Placeholder);
    }
