    var listsToAdd = new List<List<string>>();
    foreach (List<string> q in questions)
    {
       if (!groupOfQuestions.Except(q).Any())
       {
           questions.Add(groupOfQuestions);
       }
    }
    
    questions.AddRange(listsToAdd);
