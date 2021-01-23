    protected void Button3_Click(object sender, EventArgs e)
    {
        string controlName = ViewState["answerControlName"];
        ListControl answersControl = (ListControl)this.FindControl(controlName);
        if (answersControl != null)
        {
            List<string> selectedValues = answersControl.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(li => li.Value)
                .ToList();
            List<string> listOfCorrectAnswerIDs = (List<string>)ViewState["listOfCorrectAnswerIDs"];
            // check for equivalency
            string selectedString = string.Join(",", selectedValues.OrderBy(val => val));
            string correctString = string.Join(",", listOfCorrectAnswerIDs.OrderBy(val => val));
            bool allAnswersCorrect = selectedString == correctString;
        }
    }
