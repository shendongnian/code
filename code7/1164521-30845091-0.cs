    var questionPannel = lL.Items[e.ItemIndex].FindControl("lead_table") as HtmlTable;
    var campaignQuestionsTableRow = questionPannel.FindControl("campaign_questions") as HtmlTableRow;
    var questions = GetQuestions();
    foreach(var question in questions)
    {
        // This builds a WebControl for the dynamic question
        var control = CreateQuestionControl(question);
        campaignQuestionsTableRow.AddControl(control); 
    }
