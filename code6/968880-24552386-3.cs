     protected void lvQuestions_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem || e.Item.ItemType == ListViewItemType.InsertItem)
        {
            ucScoringQuestion ucQuestion = (ucScoringQuestion)e.Item.FindControl("ucScoringQuestion");
            ucQuestion.scoringQuestion = (ScoringQuestion)e.Item.DataItem;
            string pre = MyContext.CurrentLanguage == Languages.Arabic ? "<strong>س. </strong>" : "<strong>Q. </strong>";
            ucQuestion.spnQuestionNumber.InnerHtml = pre + (++QuestionNumber).ToString() + " ";
            ucQuestion.Reinitialize();
        }
    }
