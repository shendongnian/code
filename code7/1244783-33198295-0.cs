    // Check
    int userIN;
    if(int.TryParse(answerBox.Text, out userIN))
    {
        if (answ == userIN)
        {
            feedback.Text = "Correct";
        }
        else
        {
            feedback.Text = "incorrect";
        }
    }
    else
    {
        feedback.Text = "incorrect";
    }
