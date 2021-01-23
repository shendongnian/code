    // Add question data to DB.
    AddQuestion questions = new AddQuestion();
    bool addSuccess = questions.Add_Question(AuthorName.Text, 
        ImageFile.FileName,
        txtDate.Text, 
        Stem.Text, 
        ResponseA.Text, 
        ResponseB.Text, 
        ResponseC.Text, 
        ResponseD.Text, 
        ResponseE.Text,
        DDResponse.SelectedValue, 
        Critique.Text, 
        KeyLO.Text, 
        Reference.Text, 
        DDTime.SelectedValue, 
        Convert.ToInt32(DDItemBank.SelectedValue),
        Convert.ToInt32(DDCategory.SelectedValue));
    if (addSuccess)
