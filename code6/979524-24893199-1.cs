    answers.Columns.Add("Response", typeof(int));
    foreach(AnswerRow a in answer.Answers)
    {
        if(a.Response) // Here I'm trying to check if a.Response is true
            answers.Rows.Add(1);
        else
            answers.Rows.Add(0);
    }
